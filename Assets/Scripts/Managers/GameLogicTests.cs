// Una prueba que verifica el comportamiento de completar un objetivo.
    [Test]
    public void CompleteObjective_IncrementsCompletedCount()
    {
        // ARRANGE
        var gameLogic = new GameLogic(3);

        // ACT
        gameLogic.CompleteObjective();

        // ASSERT
        Assert.AreEqual(1, gameLogic.ObjectivesCompleted);
    }

    // Una prueba que verifica la condición de victoria.
    [Test]
    public void IsVictoryConditionMet_ReturnsTrue_WhenObjectivesCompleted()
    {
        // ARRANGE
        var gameLogic = new GameLogic(2);

        // ACT
        gameLogic.CompleteObjective();
        gameLogic.CompleteObjective();

        // ASSERT
        Assert.IsTrue(gameLogic.IsVictoryConditionMet);
    }
LootChestInteractionTests.cs
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LootChestInteractionTests
{
    // Las pruebas de Play Mode a menudo necesitan ser Corrutinas
    // El atributo [UnityTest] indica esto al Test Runner
    [UnityTest]
    public IEnumerator LootChest_Interact_OpensChestAndBecomesNonInteractable()
    {
        // ARRANGE: Creamos un cofre en la escena de prueba
        var chestPrefab = new GameObject();
        // Necesitamos un collider para que IInteractable funcione, pero aquí lo simulamos
        var lootChest = chestPrefab.AddComponent<LootChestController>(); 
        
        // ACT: Llamamos al método Interact() por primera vez
        lootChest.Interact();
        
        // ASSERT: Verificamos que se ha abierto.
        // Para probar esto, necesitamos modificar LootChestController para exponer su estado
        Assert.IsTrue(lootChest.IsOpened, "El cofre debería estar abierto después de la primera interacción.");

        // Hacemos una pausa de un frame. No es estrictamente necesario aquí,
        // pero es una buena práctica en pruebas más complejas
        yield return null;

        // ACT 2: Intentamos interactuar de nuevo
        // Para probar esto, necesitamos una forma de capturar el Debug.Log
        // Por ahora, nos centraremos en el estado
        lootChest.Interact();

        // ASSERT 2: Verificamos que sigue abierto y no ha cambiado
        Assert.IsTrue(lootChest.IsOpened, "El cofre debería permanecer abierto después de la segunda interacción.");
    }
}