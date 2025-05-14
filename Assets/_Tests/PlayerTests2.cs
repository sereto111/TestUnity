using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class PlayerTests2
{
    private Player player;

    // Este m�todo se ejecuta antes de cada prueba.
    [SetUp]
    public void Setup()
    {
        // Crear un objeto vac�o y a�adir el script Player
        GameObject playerObject = new GameObject();
        player = playerObject.AddComponent<Player>();
    }

    // Prueba para comprobar que la salud inicial es 100
    [Test]
    public void PlayerHealthStartsAt100()
    {
        Assert.AreEqual(100, player.health); // Assert.AreEqual
    }

    // Prueba para comprobar que el jugador recibe da�o correctamente
    [Test]
    public void PlayerTakesDamageCorrectly()
    {
        player.TakeDamage(30);
        Assert.AreNotEqual(100, player.health); // Assert.AreNotEqual
    }

    // Prueba para comprobar que la salud no baja de 0
    [Test]
    public void PlayerHealthDoesNotGoBelowZero()
    {
        player.TakeDamage(150); // Recibe da�o mayor que su salud
        Assert.AreEqual(0, player.health); // Assert.AreEqual
        Assert.IsFalse(player.health < 0); // Assert.IsFalse
    }

    // Prueba para comprobar que el jugador se cura correctamente
    [Test]
    public void PlayerHealsCorrectly()
    {
        player.TakeDamage(30); // Baja la salud
        player.Heal(20); // Cura 20 de salud
        Assert.AreEqual(90, player.health); // Assert.AreEqual
    }

    // Prueba para comprobar que la salud no sube de 100
    [Test]
    public void PlayerHealthDoesNotExceed100()
    {
        player.Heal(20); // Cura al jugador, pero su salud ya es 100
        Assert.AreEqual(100, player.health); // Assert.AreEqual
    }

    // Prueba para comprobar que la salud no es nula
    [Test]
    public void PlayerHealthIsNotNull()
    {
        Assert.IsNotNull(player.health); // Assert.IsNotNull
    }

    // Verificar que el jugador est� en el juego
    [Test]
    public void PlayerIsInGame()
    {
        Assert.IsTrue(player.gameObject.activeInHierarchy); // Assert.IsTrue
    }

    // Verificar que el jugador no est� fuera del juego
    [Test]
    public void PlayerIsNotInactive()
    {
        player.gameObject.SetActive(false);
        Assert.IsFalse(player.gameObject.activeInHierarchy); // Assert.IsFalse
    }

    // Verificar que el jugador no es el mismo objeto
    [Test]
    public void PlayerIsNotSame()
    {
        GameObject anotherPlayer = new GameObject();
        Player anotherPlayerScript = anotherPlayer.AddComponent<Player>();
        Assert.AreNotSame(player, anotherPlayerScript); // Assert.AreNotSame
    }

    // Verificar que el jugador recibe una excepci�n por da�o negativo
    [Test]
    public void PlayerThrowsExceptionOnNegativeDamage()
    {
        Assert.Throws<System.ArgumentOutOfRangeException>(() => player.TakeDamage(-10)); // Assert.Throws
    }

    // Verificar que no se lanza una excepci�n
    [Test]
    public void PlayerDoesNotThrowException()
    {
        Assert.DoesNotThrow(() => player.Heal(10)); // Assert.DoesNotThrow
    }
/*
    // Verificar que la salud es mayor que un valor espec�fico
    [Test]
    public void PlayerHealthIsGreaterThanZero()
    {
        Assert.GreaterThan(player.health, 0); // Assert.GreaterThan
    }

    // Verificar que la salud es menor que un valor espec�fico
    [Test]
    public void PlayerHealthIsLessThanHundred()
    {
        Assert.LessThan(player.health, 100); // Assert.LessThan
    }

    // Verificar que la salud es mayor o igual que un valor espec�fico
    [Test]
    public void PlayerHealthIsGreaterThanOrEqualToZero()
    {
        Assert.GreaterThanOrEqual(player.health, 0); // Assert.GreaterThanOrEqual
    }

    // Verificar que la salud es menor o igual que un valor espec�fico
    [Test]
    public void PlayerHealthIsLessThanOrEqualToHundred()
    {
        Assert.LessThanOrEqual(player.health, 100); // Assert.LessThanOrEqual
    }
*/

    // Forzar que la prueba falle
    [Test]
    public void ForceFailTest()
    {
        Assert.Fail("This test is designed to fail!"); // Assert.Fail
    }

    // Este m�todo se ejecuta despu�s de cada prueba.
    [TearDown]
    public void TearDown()
    {
        // Limpiar el objeto del jugador si es necesario
        Object.Destroy(player.gameObject);
    }
}
