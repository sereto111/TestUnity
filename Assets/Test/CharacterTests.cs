using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using NUnit.Framework;

public class CharacterTests : InputTestFixture
{
    GameObject character;
    Keyboard keyboard;

    [SetUp]
    public override void Setup()
    {
        SceneManager.LoadScene("Scenes/SimpleTesting");
        base.Setup();

        keyboard = InputSystem.AddDevice<Keyboard>();
        var mouse = InputSystem.AddDevice<Mouse>();

        // Necesario para que InputSystem detecte el teclado virtual
        Press(mouse.rightButton);
        Release(mouse.rightButton);

        // Cargar el prefab del personaje desde Resources
        character = Resources.Load<GameObject>("Character");
    }

    [Test]
    public void TestPlayerInstantiation()
    {
        GameObject characterInstance = GameObject.Instantiate(character, Vector3.zero, Quaternion.identity);
        Assert.That(characterInstance, Is.Not.Null);
    }
}