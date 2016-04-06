using UnityEngine;
using System.Collections;




public class Dialogues : MonoBehaviour
{
	

	public static Dialogue [] allDialogues;

	void Awake()
	{
		allDialogues = new Dialogue[10];
		allDialogues[0]=new Dialogue("Привет, как дела?", new Answer[]{new Answer("Отлично, а у тебя?"),new Answer("Так себе"),new Answer("Мне некогда")});
		allDialogues[0].answers[0].nextDialogue=1;
		allDialogues[1]=new Dialogue("И у меня всё хорошо. Куда идешь?", new Answer[]{new Answer("К комендантше, заселиться надо"),new Answer("Да вот, медосмотр прохожу"),new Answer("Не твоё дело")});
		allDialogues[2]=new Dialogue("Добрый день, молодой человек. Ваш пропуск?", new Answer[]{new Answer("Эмм, да мне на пару минут всего"),new Answer("Вот, пожалуйта[сделать доступным с выполнением квеста]"),new Answer("А что, нужен пропуск?")});
		allDialogues[2].answers[2].nextDialogue=3;
		allDialogues[3]=new Dialogue("Вообще-то нужен. Ааа, абитуриент! Тебе надо к коменданту подойти", new Answer[]{new Answer("Хорошо"),new Answer("Ага, делать мне больше нечего"),new Answer("")});
	}

}

public class Dialogue 
{

	public string question;
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

public class Answer
{
	string textAnswer;
	public int nextDialogue=-1;

	public Answer(string textAnswer="")
	{
		this.textAnswer=textAnswer;
	}

	public override string ToString ()
	{
		string ret=textAnswer;
		//			if(nextDialogue)
		//			{
		//				ret+=" (Leads to "+nextDialogue.ToString()+")";
		//			}
		return string.Format (ret);
	}


}
