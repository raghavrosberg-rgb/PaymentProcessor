///C# — Null-conditional assignment
using PaymentProcessor.CompoundAssignment;
using PaymentProcessor.ExpressionTree;
using PaymentProcessor.Payment;
using System.Diagnostics;

Console.WriteLine("C# — Null-conditional assignment");
var balance = new decimal(30.75);
Account amount = new()
{
    Balance = balance
};

Console.WriteLine("Balance before processing: " + amount.Balance);
PaymentProccessor PaymentProccessor = new();
PaymentProccessor.Payout(amount, new decimal(2.5));

Console.WriteLine("Balance after processing in .net 9: " + amount.Balance);

//resetting balance
amount.Balance = balance;
Console.WriteLine("Balance before processing: " + amount.Balance);
PaymentProccessor.PayoutDotNet10(amount, new decimal(2.5));
Console.WriteLine("Balance after processing in .net 10: " + amount.Balance);

/// Demonstrate compound assignment operator
Console.WriteLine("Demonstrate compound assignment operator");
// Create two Counter instances (.net 9)
var a = new CounterDontNet9(20);
var b = new CounterDontNet9(30);

// Use operator +
var c = a + b;               // returns new Counter(50)
Console.WriteLine(c.Value);  // prints 50

// Use compound assignment (compiler rewrites to a = a + b)
a += b;
Console.WriteLine(a.Value);  // prints 50

// Chaining also works
var d = new CounterDontNet9(10) + new CounterDontNet9(40) + new CounterDontNet9(50);
Console.WriteLine(d.Value); // prints 100

CounterDotnet10 _counter = new(20);
_counter += 30;
Console.WriteLine(_counter.Value); // prints 50


Console.WriteLine("Expression tree with static extension members");

//var r = Result<int, string>.Success(5);


//Console.WriteLine(r.IsError());               // False
//Console.WriteLine(r.GetValueOrDefault());    // 5

//var e = Result<int, string>.Error("x");
//Console.WriteLine(e.IsError());              // True
//Console.WriteLine(e.GetValueOrDefault());    // default(int) == 0



var ok = Result<int, string>.Success(42);
Console.WriteLine($"ok.IsSuccess = {ok.IsSuccess}"); // True

var err = Result<int, string>.Error("boom");
Console.WriteLine($"err.IsSuccess = {err.IsSuccess}"); // False


var nf = Result<int, string>.NotFound();
Console.WriteLine($"nf.IsSuccess = {nf.IsSuccess}"); // False

