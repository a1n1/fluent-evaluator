using FluentEvaluator.Actions;
using FluentEvaluator.Evaluations;

namespace FluentEvaluator.Conjunctions
{
	public class OtherwiseWhen : IOtherwiseWhen
	{
		public OtherwiseWhen(bool evaluationToPerform, EvaluationConclusion evaluationConclusion, bool continueEvaluations)
		{
			ContinueEvaluations = continueEvaluations;

			if(evaluationToPerform)
			{
				evaluationConclusion.Evaluate(true);
				ContinueEvaluations = false;
			}

			EvaluationToPerform = evaluationToPerform;

		}


		protected bool EvaluationToPerform
		{
			get;
			set;
		}

		public virtual IEvaluationAction This(bool boolToEvaluate)
		{
			EvaluationToPerform = boolToEvaluate;

			return new EvaluationAction(boolToEvaluate, EvaluationToPerform, ContinueEvaluations);
		}

		protected bool ContinueEvaluations
		{
			get; set;
		}

		public virtual ObjectEvaluation<TypeToEvaluate> This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			return new ObjectEvaluation<TypeToEvaluate>(objectToEvaluate, ContinueEvaluations);
		}
	}

	public interface IOtherwiseWhen:IWhen
	{
	}
}