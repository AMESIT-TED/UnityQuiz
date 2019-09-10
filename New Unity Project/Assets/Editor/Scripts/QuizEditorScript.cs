using UnityEditor;


[CustomEditor(typeof(Quiz))]
public class QuizEditor : Editor {
   //  public override void OnInspectorGUI() {
   //     Quiz quiz = (Quiz)target;

   //    quiz.type = (Quiz.QuestionType)EditorGUILayout.EnumPopup("Question Type", quiz.type);

   //    if(quiz.type == Quiz.QuestionType.Text) {
   //       SerializedProperty property = serializedObject.FindProperty("questions");
   //       EditorGUILayout.PropertyField(property, true);
   //    }
   // }
}
