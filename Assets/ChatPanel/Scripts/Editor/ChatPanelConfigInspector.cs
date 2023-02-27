using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace WCP
{
    [CustomEditor(typeof(ChatPanelExample))]
    public class CardConfigInspector : Editor
    {
        private bool m_isI = false;
        private int m_photoId = -1;
        private string m_text = "";
        private readonly List<int> m_photoIdList = new List<int>();
        private readonly List<string> m_photoIdStringList = new List<string>();


        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            ChatPanelExample cpe = target as ChatPanelExample;
            if (cpe == null)
                return;
            WChatPanel wcp = cpe.wcp;

            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            m_isI = EditorGUILayout.Toggle("Is I:", m_isI);
            m_photoId = EditorGUILayout.IntPopup("PhotoId:", m_photoId, m_photoIdStringList.ToArray(), m_photoIdList.ToArray());
            EditorGUILayout.BeginHorizontal();
            m_text = EditorGUILayout.TextField("Say:", m_text);
            if (GUILayout.Button("Send") && Application.isPlaying)
            {
                wcp.AddChatAndUpdate(!m_isI, m_text, m_photoId);
                m_text = "";
                GUIUtility.keyboardControl = 0;
            }

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Clear") && Application.isPlaying)
                wcp.Clear();

            if (GUILayout.Button("Test Many") && Application.isPlaying)
                cpe.PerformanceTest(2000);

            EditorGUILayout.EndHorizontal();
        }
    }
}