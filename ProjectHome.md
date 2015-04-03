I am writing this with the intent of making evaluations/conditional logic more linguistically appealing in the c# language. Some syntactic sugar to sweeten your code. It is somewhat inspired by the linguistics behind BDD context specifications utilized by such BDD frameworks as specunit.net - http://code.google.com/p/specunit-net/

## Evaluation Actions ##
```
//create the object
currentFoo = When.This(currentFoo).IsNull.CreateIt();        

//evaluate a boolean
When.This(isTrue).DoThis(() => currentFoo.AddBar()).Evaluate();

//throw an exception
When.This(currentFoo).IsNull.ThrowAnException<FooException>().Evaluate();

//perform a custom evaluation
When.This(currentFoo).Satisfies(foo => foo.bar == "asdf")
	.DoThis(() => count++ ).Evaluate();

//perform an else condition
When.This(currentFoo).Satisfies(foo => foo.bar == "asdf")
	.DoThis(() => count++ )
.Otherwise
	.DoThis(() => count--).Evaluate();

//perform an else if condition
When.This(currentFoo).IsNull
	.DoThis(() => currentFoo = new Foo())
.Otherwise.When.This(currentFoo).Satisfies(foo => foo.bar == "asdf")
	.DoThis(() => currentFoo.bar = "juice").Evaluate();
```

## Conjunctions ##
```
//an and conjunction
When.This(currentFoo).IsNull
.And.When.This(currentFooCollection).IsEmpty
.DoThis(() => count++).Evaluate();

//an or conjunction
When.This(currentFoo).IsNull
.Or.When.This(count).EqualsThis(42)
.DoThis(() => count++).Evaluate();
```

## Evaluations ##
```
IsNull

IsNotNull

IsEmpty

IsNotEmpty

EqualsThis(someObject)

Satisfies(someObject => someObject.Id == 13)
```