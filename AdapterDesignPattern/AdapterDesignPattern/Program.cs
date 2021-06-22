using System;
using System.Collections.Generic;

namespace AdapterDesignPattern
{
	//this class olay types words in English and cannot understand other languages 
	public class EnglishTyper
	{
		private ITranslator translator;

		public EnglishTyper(ITranslator translator)
		{
			this.translator = translator;
		}

		public void Type()
		{
			translator.translate("Hello");
		}
	}

	//Interface helps the English typer to understand spanish by translating the word for it
	public interface ITranslator
	{
		void translate(string englishWord);
	}

	//translates the word typed by the spanish typer so the english typer can understand it
	public class Translator : SpanishTyper, ITranslator
	{
		public void translate(string englishWord)
		{
			if (TyperInSpanish() == "Hola")
			{
				Console.WriteLine("Hello");
			}
		}
	}

	//this class can only type in Spanish 
	public class SpanishTyper
	{
		public string TyperInSpanish()
		{
			return "Hola";
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Translator translator = new Translator();
			EnglishTyper englishTyper = new EnglishTyper(translator);
			englishTyper.Type();
			Console.ReadKey();

		}
	}

}

