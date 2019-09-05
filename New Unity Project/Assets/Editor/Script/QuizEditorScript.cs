using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(Quiz))]


public class QuizEditorScript : Editor
{
   public override void OnInspectorGUI(){
       Quiz myQuizScript = (Quiz)target;

    //The type of enum and its features

         _quizType = (Type)EditorGUILayout.EnumPopup("Type of Quiz", myQuizScript.type);


   }
}
