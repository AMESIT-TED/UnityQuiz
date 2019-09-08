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

       myQuizScript.type = (Quiz.QuestionType)EditorGUILayout.EnumPopup("Question Type", myQuizScript.type);

      if(myQuizScript.type== Quiz.QuestionType.Text){
      //  myQuizScript.questions = EditorGUI.PropertyField(,myQuizScript.questions);
     Debug.Log("yay");

   }
   }
   }
