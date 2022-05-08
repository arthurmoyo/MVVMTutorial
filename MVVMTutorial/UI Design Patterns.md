# UI Design Patterns - In depth look into MVVM with a demo 
## Dariel 
### Presented by Arthur Moyo 

# What is MVVM?

) – be it via a markup language or GUI code – from the development of the business logic or back-end logic (the model) so that the view is not dependent on any specific model platform.
MVVM architecture facilitates a separation of development of the graphical user interface with the help of mark-up language or GUI code. The full form of MVVM is Model-View-ViewModel.

The view model of MVVM is a value converter that means that it is view model's responsibility for exposing the data objects from the Model in such a way that objects are easily managed and presented.


There are three core components in the MVVM pattern: the model, the view, and the view model.


In addition to understanding the responsibilities of each component, 
it's also important to understand how they interact with each other. 
At a high level, 
    the view "knows about" the view model, and the view model "knows about" the model, but the model is unaware of the view model, 
    and the view model is unaware of the view. 
    Therefore, the view model isolates the view from the model, and allows the model to evolve independently of the view.

x However, in some cases, the code-behind might contain UI logic that implements visual behavior that is difficult to express in XAML, such as animations.

