using UnityEngine;
using System.Collections;




public class Dialogues : MonoBehaviour
{
	public class Dialogue : MonoBehaviour 
	{
		
		string question;
		public Answer [] answers;
		
		public Dialogue(string question, Answer [] newAnswers)
		{
			this.question=question;
			this.answers=new Answer[newAnswers.Length];
			for(int i=0;i<answers.Length;i++)
			{
				answers[i]=newAnswers[i];
			}
		}

		public override string ToString ()
		{
			return string.Format ("Question: {0}. Answers: {1}, {2}, {3}",question,answers[0],answers[1],answers[2]);
		}
		
	}
	
	public class Answer : MonoBehaviour
	{
		string textAnswer;
		public Dialogue nextDialogue;
		
		public Answer(string textAnswer)
		{
			this.textAnswer=textAnswer;
		}

		public override string ToString ()
		{
			string ret=textAnswer;
			if(nextDialogue)
			{
				ret+=" (Leads to "+nextDialogue.ToString()+")";
			}
			return string.Format (ret);
		}
		
		
	}

	public static Dialogue [] allDialogues;

	void Awake()
	{
		allDialogues = new Dialogue[10];
		allDialogues[0]=new Dialogue("Привет, как дела?", new Answer[]{new Answer("Отлично, а у тебя?"),new Answer("Так себе"),new Answer("Мне некогда")});
		allDialogues[1]=new Dialogue("И у меня всё хорошо. Куда идешь?", new Answer[]{new Answer("К комендантше, заселиться надо"),new Answer("Да вот, медосмотр прохожу"),new Answer("Не твоё дело")});
		allDialogues[0].answers[0].nextDialogue=allDialogues[1];
		Debug.Log(allDialogues[0].ToString());
		Debug.Log(allDialogues[1].ToString());
	}

}
