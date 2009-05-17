namespace FluentEvaluator.Conjunctions
{
	public class Or
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

		public Or(bool evaluationToPerform, bool continueEvaluations, object objectToEvaluate)
		{
			EvaluationToPerform = evaluationToPerform;
			ContinueEvaluations = continueEvaluations;
			ObjectToEvaluate = objectToEvaluate;
		}

		protected object ObjectToEvaluate { get; set; }

		public virtual OrWhen When
		{
			get
			{
				return new OrWhen(EvaluationToPerform, ContinueEvaluations, ObjectToEvaluate);
			}
		}
	}
}