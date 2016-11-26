# Tag Sharp

Tag# collection of .net core tag helpers. The plan is to include as many as possible. At this point only bootstrap 
is available.

In order to start using the Tag# tag helpers, first use nuget to include the package. then open _ViewImports.cshtml to 
indicate that you intend to use the Tag# tag helpers as shown below:

```csharp
@addTagHelper *, TagSharp
```

Now you are all set to start using Tag# tag helpers.

For example in order to create a simple label here is what you can do.

```html
<ts-bootstrap-label>Default</ts-bootstrap-label>
<ts-bootstrap-label-primary>Primary</ts-bootstrap-label-primary>
<ts-bootstrap-label bs-css-class="label-danger">Danger</ts-bootstrap-label>
```

Similarly in order to create a panel, here is what you can do.

```html
<ts-bootstrap-panel>
    <ts-bootstrap-panel-header>
        <strong>Default Panel</strong>
    </ts-bootstrap-panel-header>
    <ts-bootstrap-panel-body>
        Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's 
        standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make 
        a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, 
        remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing 
        Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including 
        versions of Lorem Ipsum.
    </ts-bootstrap-panel-body>
    <ts-bootstrap-panel-footer>
        Thank You!
    </ts-bootstrap-panel-footer>
</ts-bootstrap-panel>
```

There is a demo included in this project to fully explain the entire list of possiblities!!
