using System;
using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public class NumericEvaluation<TypeToEvaluate> : INumericEvaluation<EvaluationAction, TypeToEvaluate>
		where TypeToEvaluate : IComparable<TypeToEvaluate>
	{
		public NumericEvaluation(TypeToEvaluate objectToEvaluate, bool continueEvaluations)
		{
			ObjectToEvaluate = objectToEvaluate;
			ContinueEvaluations = continueEvaluations;
		}

		protected bool ContinueEvaluations { get; set; }

		protected virtual TypeToEvaluate ObjectToEvaluate
		{
			get;
			set;
		}

		protected virtual bool EvaluationToPerform
		{
			get;
			set;
		}

		public EvaluationAction Equals(TypeToEvaluate objectToEqual)
		{
			EvaluationToPerform = Equals(CompareType.EqualTo, EvaluationUtilities.GetComparisonType(objectToEqual.CompareTo(ObjectToEvaluate)));
			
			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}

		public EvaluationAction IsGreaterThan(TypeToEvaluate numericValue)
		{
            EvaluationToPerform = Equals(CompareType.GreaterThan, EvaluationUtilities.GetComparisonType(ObjectToEvaluate.CompareTo(numericValue)));

			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}

		public EvaluationAction IsLessThan(TypeToEvaluate numericValue)
		{
            EvaluationToPerform = Equals(CompareType.LessThan, EvaluationUtilities.GetComparisonType(numericValue.CompareTo(ObjectToEvaluate)));

			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}
	}
}