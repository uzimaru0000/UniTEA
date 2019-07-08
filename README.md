# ![logo](./images/logo.png)

UniTEA is an implementation of The Elm Architecture for Unity3D.

## Environment

- Unity3D 2018.4
- C# 6

## Install

Comming soon...

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

3. Create a class that wraps the message. Implement the `IMessage<Msg>` interface.

   ```c#
   using UniTEA;
   
   public class IncreaseMsg : IMessage<Msg>
   {
   	public Msg GetMessage() => Msg.Increase;
   }
   
   public class DecreaseMsg : IMessage<Msg>
   {
   	public Msg GetMessage() => Msg.Decrease;
   }
   ```

4. Create Updater class. Implement the `IUpdater<Model, Msg>` interface.

   ```c#
   using UniTEA;
   
   public class Updater : IUpdater<Model, Msg>
   {
   	public (Model, Cmd<Msg>) Update(IMessage<Msg> msg, Model model)
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

5. Create Renderer class. Implement the `IRenderer<Model>` interface.

   ```c#
   using UnityEngine;
   using UnityEngine.UI;
   using UniTEA;
   
   public class Renderer : MonoBehaviour, IRenderer<Model>
   {
   	[SerializeField]
   	Text display;
   	
   	public void Renderer(Model model)
   	{
   		display.text = model.count.ToString();
   	}
   }
   ```

6. Create Dispatcher class. If you are handling events in another class, you do not have to create one.
   Also, refer to the TEA class in any way. (Eg: singleton, injection from the inspector)

   ```c#
   using UnityEngine;
   using UnityEngine.UI;
   using UniTEA;
   
   public class Dispatcher : MonoBehaviour
   {
   	[SerializeField]
   	TEAManager manager;
   
   	[SerializeField]
   	Button increaseButton;
   	
   	[SerializeField]
   	Button decreaseButton;
   	
   	void Start()
   	{
   		increaseButton.onClick.AddListener(() => manager.Commit(new IncreaseMsg()));
   		decreaseButton.onClick.AddListener(() => manager.Commit(new DecreaseMsg()));
   	}
   }
   ```

7. Create TEAManager class. Make it singleton if necessary. For the TEA object, provide an initialization function, an instance of Updater, and an instance of Renderer.

   ```c#
   using UniTEA;
   using UnityEngine;
   
   public class TEAManager : MonoBehaviour
   {
   	TEA<Model, Msg> teaInstance;
   	
   	[SerializeField]
   	new Renderer renderer;
   	
   	void Start()
   	{
   		teaInstance = new TEA<Model, Msg>(
   			() => (new Model(), Cmd<Msg>.none),
   			new Updater(),
   			renderer
   		);
   	}
   	
   	public void Commit(IMessage<Msg> msg)
   	{
   		teaInstance.Commit(msg);
   	}
   }
   ```

## Example

- [Counter]()
- [Simple write value]()
- [TodoList]()
- [HTTP]()

## Contribution

1. Fork it

2. Create your feature branch (git checkout -b my-new-feature)
3. Commit your changes (git commit -am 'Add some feature')
4. Push to the branch (git push origin my-new-feature)
5. Create new Pull Request
