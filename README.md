# ![logo](./images/logo.png)

UniTEA is an implementation of The Elm Architecture for Unity3D.

## Environment

- Unity3D 2018.4 or higher
- C# 7.0

## Install

Add line in Packages/manifest.json

```json
{
  "dependencies" : {
    ...
    "com.uzimaru0000.unitea": "https://github.com/uzimaru0000/UniTEA.git",
    ...
  }
}
```

## Usage

1. Create your application Model. You should use struct.

   ```c#
   public struct Model
   {
      public int count;
   }
   ```

2. Create a message for your application. You should use enum.

   ```c#
   public enum Msg
   {
   	Increase,
   	Decrease
   }
   ```

3. Create a class that wraps the message. Implement the `IMessenger<Msg>` interface.

   ```c#
   using UniTEA;

   public class IncreaseMsg : IMessenger<Msg>
   {
   	public Msg GetMessage() => Msg.Increase;
   }

   public class DecreaseMsg : IMessenger<Msg>
   {
   	public Msg GetMessage() => Msg.Decrease;
   }
   ```

4. Create Updater class. Implement the `IUpdater<Model, Msg>` interface.

   ```c#
   using UniTEA;

   public class Updater : IUpdater<Model, Msg>
   {
   	public (Model, Cmd<Msg>) Update(IMessenger<Msg> msg, Model model)
   	{
   		switch (msg)
   		{
   			case IncreaseMsg _:
   				return (new Model
   				{
   					count = model.count + 1;
   				}, Cmd<Msg>.none);
   			case DecreaseMsg _:
   				return (new Model
   				{
   					count = model.count - 1;
   				}, Cmd<Msg>.none);
   			default:
   				return (model, Cmd<Msg>.none);
   		}
   	}
   }
   ```

5. Create Renderer class. Implement the `IRenderer<Model, Msg>` interface.

   ```c#
   using UnityEngine;
   using UnityEngine.UI;
   using UniTEA;

   public class Renderer : MonoBehaviour, IRenderer<Model>
   {
   	[SerializeField]
   	Text display;
      [SerializeField]
      Button increaseBtn;
      [SerializeField]
      Button decreaseBtn;

      public void Init(System.Action<IMessenger<Msg>> dispatcher)
      {
         increaseBtn.onClick.AddListener(() => dispatcher(new IncreaseMsg()));
         decreaseBtn.onClick.AddListener(() => dispatcher(new DecreaseMsg()));
      }

   	public void Renderer(Model model)
   	{
   		display.text = model.count.ToString();
   	}
   }
   ```

6. Create TEAManager class. Make it singleton if necessary. For the UniTEA object, provide an initialization function, an instance of Updater, and an instance of Renderer.

   ```c#
   using UniTEA;
   using UnityEngine;

   public class TEAManager : MonoBehaviour
   {
   	UniTEA<Model, Msg> tea;

   	[SerializeField]
   	new Renderer renderer;

   	void Start()
   	{
   		tea = new TEA<Model, Msg>(
   			() => (new Model(), Cmd<Msg>.none),
   			new Updater(),
   			renderer
   		);
   	}
   }
   ```

## Example

**TODO: Coming soon!**

**I'm happy if you contribute！**

## Development

1. Make your project and make directory Packages in it.
2. In Packages, `git clone https://github.com/uzimaru0000/UniTEA.git`
3. Install UniTEA from clone.

## Contribution

1. Fork it
2. Create your feature branch (git checkout -b my-new-feature)
3. Commit your changes (git commit -am 'Add some feature')
4. Push to the branch (git push origin my-new-feature)
5. Create new Pull Request
