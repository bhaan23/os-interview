### Question 1

```
class Animal
{
	public virtual string speak(int x) { return "silence"; }
}

class Cat : Animal
{
	public string speak(int x) { return "meow"; }
}

class Dog : Animal
{
	public string speak(short x) { return "bow-wow"; }
}
```
> Explain why the block below does not emit "bow-wow"
> ```
> Animal d = new Dog();
> Console.Write(d.speak(0));
> ```

While `d` is created as a `Dog`, there are two problems from reaching the `speak` method of `Dog` rather than of `Animal`. First, since `d` is cast as type `Animal`, when we call `speak` we are specifically calling the `Animal` `speak` that can be overridden, rather than the `speak` defined in `Dog` that has a different parameter type (`short` vs `int`), which is technically considered a different method. Secondly, even if `Dog` defined the same `speak` method as `Cat`, you would still have the issue of the method not being defined as an `override`. This means that even though the function has the same definitions, because `d` is considered type `Animal`, it will look for the `Animal` definition of the function, which includes any `override`s but not any "duplicate" method definitions. So to correctly emit "bow-wow" you would have to define the `Dog` class as follows:
```
class Dog : Animal
{
	public override string speak(int x) { return "bow-wow"; }
}
```

---

### Question 2

```
class A
{
	public int a { get; set; }
	public int b { get; set; }
}

class B
{
	public const A a;
	public B() { a.a = 10; }
}

int main()
{
	B b = new B();
	Console.WriteLine("%d %d\n", b.a.a, b.a.b);
	return 0;
}
```
> Outline any issues/concerns with the implemented code.

I will assume naming conventions are intentionally simplified here, as are the classes (as `B` seems a bit useless right now), and that any error handling is not intended to be included in the `main` method otherwise those would be my first concerns. My second concern is the `const` definition of `a` within `B`. `const` is supposed to be a static value that's set for the whole program rather than a representation of a value that shouldn't change throughout the class instance. So either `a` should be defined statically, not in the constructor of `B` or `A` should be changed to be `readonly`, which would limit changing `a` for the lifetime of `B` but still allow you to set the initial value of `a.a` to `10`. My third and final concern would be that there is no value for `b.a.b`. In this case it should default to `0` which works fine for formatting, but if it was changed to be nullable, you could run into a formatting exception trying to convert `null` to an `int`.