namespace FluentEvaluator.Conjunctions
{
	public class And
	{
		protected bool EvaluationToPerform
		{
			get;
			set;
		}

		protected bool ContinueEvaluations
		{
			get;
			set;
		}

		public And(bool evaluationToPerform, bool continueEvaluations, object objectToEvaluate)
		{
			EvaluationToPerform = evaluationToPerform;
			ContinueEvaluations = continueEvaluations;
			ObjectToEvaluate = objectToEvaluate;
		}

		protected object ObjectToEvaluate { get; set; }

		public virtual AndWhen When
		{
			get
			{
				return new AndWhen(EvaluationToPerform, ContinueEvaluations, ObjectToEvaluate);
			}
		}
	}
}