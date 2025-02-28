using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
[System.Serializable]
public class StoryScene : GameScene
{
    public List<Sentence> sentences;
    public Sprite background;
    public GameScene nextScene;



    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Speaker speaker;
        public List<Action> actions;

        public AudioClip music;
        public AudioClip sound;

        [System.Serializable]
        public struct Action
        {
            public Speaker speaker;
            public int spriteIndex;
            public Type actionType;
            public Vector2 coords;

            [System.Serializable]
            public enum Type
            {
                NONE, APPEAR, DISAPPEAR
            }
        }
    }
    }

public class GameScene : ScriptableObject { }