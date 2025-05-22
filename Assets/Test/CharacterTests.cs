using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using StarterAssets;
using System.IO; // Necesario para acceder a PlayerHealth

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

        Press(mouse.rightButton);
        Release(mouse.rightButton);

        character = Resources.Load<GameObject>("Character");
    }

    [Test]
    public void TestPlayerInstantiation()
    {
        GameObject characterInstance = GameObject.Instantiate(character, Vector3.zero, Quaternion.identity);
        Assert.That(characterInstance, Is.Not.Null);
    }

    [UnityTest]
    public IEnumerator TestPlayerMoves()
    {
        GameObject characterInstance = GameObject.Instantiate(character, Vector3.zero, Quaternion.identity);

        Press(keyboard.upArrowKey);
        yield return new WaitForSeconds(1f);
        Release(keyboard.upArrowKey);
        yield return new WaitForSeconds(1f);

        Assert.That(characterInstance.transform.position.z, Is.GreaterThan(1.5f));
    }

    [UnityTest]
    public IEnumerator TestPlayerFallDamage()
    {
        GameObject characterInstance = GameObject.Instantiate(character, new Vector3(0f, 4f, 17.2f), Quaternion.identity);

        var characterHealth = characterInstance.GetComponent<PlayerHealth>();
        Assert.That(characterHealth.Health, Is.EqualTo(1f));

        Press(keyboard.upArrowKey);
        yield return new WaitForSeconds(0.5f);
        Release(keyboard.upArrowKey);
        yield return new WaitForSeconds(2f);

        Assert.That(characterHealth.Health, Is.EqualTo(0.9f));
    }

    [TearDown]
    public void Teardown()
    {
        foreach (var gameObject in GameObject.FindObjectsOfType<GameObject>())
        {
            GameObject.Destroy(gameObject);
        }

        InputSystem.RemoveDevice(keyboard);
    }
}
