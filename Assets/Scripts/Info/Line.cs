using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace RedPanda
{
    [Serializable]
    public class Lines<TKey, TValue>
    {
        [SerializeField] private List<Line<TKey, TValue>> _collection = new();
        public int Count => _collection.Count;

        public void Add(TKey key, TValue value)
        {
            if (!GetKeys().Contains(key))
            {
                _collection.Add(new Line<TKey, TValue>(key, value));
            }
        }

        public void Remove(TKey key)
        {
            List<TKey> keys = GetKeys();

            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i].Equals(key))
                {
                    _collection.RemoveAt(i);
                    break;
                }
            }
        }

        public void RemoveDuplicates()
        {
            // Create a new list with distinct keys
            List<TKey> distinctKeys = GetKeys().Distinct().ToList();

            // Create a new list with the corresponding lines
            List<Line<TKey, TValue>> distinctLines = new();

            foreach (TKey key in distinctKeys)
            {
                //Gets the line.
                Line<TKey, TValue> line = _collection.Find(x => x.Key.Equals(key));

                if (line != null)
                {
                    distinctLines.Add(line);
                }
            }

            // Update the _collection field
            _collection = distinctLines;
        }

        public List<TKey> GetKeys()
        {
            return _collection.Select(line => line.Key).ToList();
        }

        public TValue GetValue(TKey key)
        {
            List<TKey> keys = GetKeys();

            return keys.Contains(key) ? _collection[keys.IndexOf(key)].Value : default;
        }

        public List<TValue> GetValues()
        {
            return _collection.Select(line => line.Value).ToList();
        }
    }

    [Serializable]
    public class Line<TKey, TValue>
    {
        [SerializeField] private TKey _key;
        [SerializeField] private TValue _value;

        public TKey Key { get => _key; set => _key = value; }
        public TValue Value { get => _value; set => _value = value; }

        public Line(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }

#if UNITY_EDITOR

    [CustomPropertyDrawer(typeof(Line<,>))]
    public class LineDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            // Calculate the rectangle for the key field
            Rect keyRect = new(position.x, position.y, position.width * 0.5f, position.height);
            SerializedProperty keyProperty = property.FindPropertyRelative("_key");

            // Calculate the rectangle for the value field
            Rect valueRect = new(position.x + position.width * 0.5f, position.y, position.width * 0.5f, position.height);
            SerializedProperty valueProperty = property.FindPropertyRelative("_value");

            // Draw the key and value fields using the default editor
            EditorGUI.PropertyField(keyRect, keyProperty, GUIContent.none);
            EditorGUI.PropertyField(valueRect, valueProperty, GUIContent.none);

            EditorGUI.EndProperty();
        }
    }

#endif
}