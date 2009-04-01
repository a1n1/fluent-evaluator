using System;
using FluentEvaluator.Actions;

namespace FluentEvaluator.Evaluations
{
	public class NumericEvaluation<TypeToEvaluate> : Evaluation<EvaluationAction, TypeToEvaluate>, INumericEvaluation<EvaluationAction, TypeToEvaluate>
		where TypeToEvaluate : IComparable<TypeToEvaluate>
	{
		public NumericEvaluation(TypeToEvaluate objectToEvaluate, bool continueEvaluations) : base(objectToEvaluate, continueEvaluations)
		{
		}

		public override EvaluationAction EqualsThis(TypeToEvaluate objectToEqual)
		{
			EvaluationToPerform = Equals(CompareType.EqualTo, EvaluationUtilities.GetComparisonType(ObjectToEvaluate.CompareTo(objectToEqual)));
			
			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}

		public EvaluationAction IsGreaterThan(TypeToEvaluate numericValue)
		{
			EvaluationToPerform = Equals(CompareType.GreaterThan, EvaluationUtilities.GetComparisonType(ObjectToEvaluate.CompareTo(numericValue)));

			return new SingularAction<TypeToEvaluate>(ObjectToEvaluate, EvaluationToPerform);
		}

		public EvaluationAction IsGreaterThanOrEqualTo(TypeToEvaluate numericValue)
		{
			throw new NotImplementedException();
		}

		public EvaluationAction IsLessThan(TypeToEvaluate numericValue)
		{
			throw new NotImplementedException();
		}

		public EvaluationAction IsLessThanOrEqualTo(TypeToEvaluate numericValue)
		{
			throw new NotImplementedException();
		}
	}
}