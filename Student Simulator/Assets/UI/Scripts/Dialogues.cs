using UnityEngine;
using System.Collections;
using Quest.Common.Core;



public class Dialogues : MonoBehaviour
{
	

	public static Dialogue [] allDialogues;

	void Awake()
	{
		allDialogues = new Dialogue[25];
		allDialogues[0]=new Dialogue("Привет, как дела?", new Answer[]{new Answer("Отлично, а у тебя?"),new Answer("Да вот, заселяюсь потихоньку"),new Answer("Мне некогда")});
		allDialogues[0].answers[0].nextDialogue=1;
		allDialogues[1]=new Dialogue("И у меня всё хорошо. Куда идешь?", new Answer[]{new Answer("К комендантше, заселиться надо"),new Answer("Да вот, медосмотр прохожу"),new Answer("Не твоё дело")});
		allDialogues[1].answers[0].nextDialogue=4;
		allDialogues[2]=new Dialogue("Добрый день, молодой человек. Ваш пропуск?", new Answer[]{new Answer("Эмм, да мне на пару минут всего"),new Answer("Вот, пожалуйта[сделать доступным с выполнением квеста]"),new Answer("А что, нужен пропуск?")});
		allDialogues[2].answers[2].nextDialogue=3;
		allDialogues[3]=new Dialogue("Вообще-то нужен. Ааа, абитуриент! Тебе надо к коменданту подойти. Проходи в 103 комнату", new Answer[]{new Answer("Хорошо"),new Answer("Ага, делать мне больше нечего"),new Answer("")});
		allDialogues[0].answers[1].nextDialogue=4;

		allDialogues[3].answers[0].SetQuest(1,15);

		//

		//
		allDialogues[4]=new Dialogue("О, так ты первокурсник? Если хочешь, можешь к нам заселиться, попроси у коменды 303 комнату.", new Answer[]{new Answer("Классно, спасибо![Квест на комнату]"),new Answer("Я подумаю"),new Answer("")});



		allDialogues[1].answers[1].nextDialogue=5;
		allDialogues[5]=new Dialogue("Это тебе к комендантше, в 103", new Answer[]{new Answer("Та я знаю"),new Answer("А это где вообще?"),new Answer("")});
		allDialogues[5].answers[1].nextDialogue=6;
		allDialogues[6]=new Dialogue("Ты реально ничего не знаешь еще. 1 - первый этаж значит, 3 - третья комната. Да и на двери написано", new Answer[]{new Answer("Спасибо!"),new Answer("Угу, понял"),new Answer("")});
		allDialogues[2].answers[0].nextDialogue=7;
		allDialogues[7]=new Dialogue("Никаких \"На пару минут\"! Знаем мы вас таких!", new Answer[]{new Answer("А как мне тогда заселиться в общежитие? Пропуск же нужен?"),new Answer("Не очень-то и хотелось!"),new Answer("")});
		allDialogues[7].answers[0].nextDialogue=3;
		//коменда
		allDialogues[8]=new Dialogue("Добрый день! Чем могу помочь?", new Answer[]{new Answer("Здравствуйте, я абитуриент, вот, заселяюсь"),new Answer("Драсьте, меня к вам послали"),new Answer("Ой, дверью ошибся")});
		allDialogues[8].answers[0].nextDialogue=9;
		allDialogues[9]=new Dialogue("Отлично! Давай документы, будем заселять тебя", new Answer[]{new Answer("А можно мне в 303 комнату?"),new Answer("Хорошо, вот документы"),new Answer("Ой, кажется, я забыл документы")});
		allDialogues[8].answers[1].nextDialogue=10;
		allDialogues[10]=new Dialogue("\"Послали\", это не ко мне. Покиньте кабинет!", new Answer[]{new Answer("Извините"),new Answer(""),new Answer("")});
		allDialogues[9].answers[0].nextDialogue=11;
		allDialogues[11]=new Dialogue("В 303? Уверен? Там живут одни нарушители спокойствия.", new Answer[]{new Answer("Правда? Отлично!"),new Answer("Хм, тогда, пожалуй, другая комната подойдет"),new Answer("")});
		allDialogues[11].answers[1].nextDialogue=12;
		allDialogues[12]=new Dialogue("Тогда 208 тебе подойдет. Отличные парни живут.", new Answer[]{new Answer("Спасибо, что предупредили за 303"),new Answer("А в 303 все-таки можно?"),new Answer("")});
		allDialogues[12].answers[0].nextDialogue=13;
		allDialogues[12].answers[1].nextDialogue=11;
		allDialogues[11].answers[0].nextDialogue=13;
		allDialogues[13]=new Dialogue("Готово. Вот твой пропуск, подойди к вахтерше, запишись у неё.", new Answer[]{new Answer("Хорошо"),new Answer("Ага, сделаю"),new Answer("")});
		allDialogues[13].answers[0].SetQuest(2,16);
		allDialogues[13].answers[1].SetQuest(2,16);
		allDialogues[13].answers[2].SetQuest(2,16);

		//

		allDialogues[14]=new Dialogue("Ну что, попросился уже в нашу комнату?", new Answer[]{new Answer("Еще нет"),new Answer("Да, уже все сделано"),new Answer("")});
		allDialogues[4].answers[0].SetQuest(0,14);

		allDialogues[15]=new Dialogue("103 комната. На первом этаже. Проходите, дверь открыта", new Answer[]{new Answer("Понял"),new Answer("Уже все сделал. Вот пропуск"),new Answer("")});
		allDialogues[16]=new Dialogue("Что-то еще? Я же сказала, иди к вахтеру", new Answer[]{new Answer("Точно, спасибо"),new Answer("Понял"),new Answer("")});
		allDialogues[17]=new Dialogue("Молодец! Можешь идти в свою комнату", new Answer[]{new Answer("Спасибо"),new Answer("Иду"),new Answer("")});

		allDialogues[15].answers[1].nextDialogue=17;


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
	public int nextDialogue=-1, nextQuestDialogue=-1;
	public int questNumber=-1;

	public Answer(string textAnswer="")
	{
		this.textAnswer=textAnswer;
	}

	public override string ToString ()
	{
		string ret=textAnswer;
		return string.Format (ret);
	}

	public void SetQuest(int questN, int questDialogue)
	{
		nextQuestDialogue=questDialogue;
		questNumber=questN;
	}

}
