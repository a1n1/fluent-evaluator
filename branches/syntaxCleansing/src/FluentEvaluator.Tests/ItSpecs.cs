using NUnit.Framework;
using SpecUnit;

namespace FluentEvaluator.Tests
{
	public class ItSpecs : ContextSpecification
	{
		protected string _testableString;
		protected bool _evaluationOccured;
	}

	[TestFixture]
	[Concern("It pronoun")]
	public class when_using_it_with_a_true_and_expression : ItSpecs
	{
		protected override void Context()
		{
			_testableString = "asdf";
			_evaluationOccured = false;

			When.This(_testableString).IsNotEmpty
				.And
				.When.It.IsNotNull
				.DoThis(() => _evaluationOccured = true)
				.Evaluate();
		}

		[Test]
		[Observation]
		public void should_be_true()
		{
			_evaluationOccured.ShouldBeTrue();
		}

	}

	[TestFixture]
	[Concern("It pronoun")]
	public class when_using_it_with_a_false_and_expression : ItSpecs
	{
		protected override void Context()
		{
			_testableString = null;
			_evaluationOccured = false;

			When.This(_testableString).IsNotEmpty
				.And
				.When.It.IsNotNull
				.DoThis(() => _evaluationOccured = true)
				.Evaluate();
		}

		[Test]
		[Observation]
		public void should_be_false()
		{
			_evaluationOccured.ShouldBeFalse();
		}

	}

	[TestFixture]
	[Concern("It pronoun")]
	public class when_using_it_with_a_true_or_expression : ItSpecs
	{
		protected override void Context()
		{
			_testableString = "asdf";
			_evaluationOccured = false;

			When.This(_testableString).IsNotEmpty
				.Or
				.When.It.Equals("asdf")
				.DoThis(() => _evaluationOccured = true)
				.Evaluate();
		}

		[Test]
		[Observation]
		public void should_be_true()
		{
			_evaluationOccured.ShouldBeTrue();
		}

	}

	[TestFixture]
	[Concern("It pronoun")]
	public class when_using_it_with_a_false_or_expression : ItSpecs
	{
		protected override void Context()
		{
			_testableString = null;
			_evaluationOccured = false;

			When.This(_testableString).IsNotEmpty
				.Or
				.When.It.Equals("")
				.DoThis(() => _evaluationOccured = true)
				.Evaluate();
		}

		[Test]
		[Observation]
		public void should_be_false()
		{
			_evaluationOccured.ShouldBeFalse();
		}

	}
}