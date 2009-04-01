using System;
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

		public virtual IEvaluation This<TypeToEvaluate>(TypeToEvaluate objectToEvaluate)
		{
			IComparable comparable = objectToEvaluate as IComparable;

			if (comparable != null)
				return new ComparableEvaluation<TypeToEvaluate>(objectToEvaluate, true);

			return new ObjectEvaluation<TypeToEvaluate>(objectToEvaluate, true);
		}
	}

	public interface IOtherwiseWhen:IWhen
	{
	}
}