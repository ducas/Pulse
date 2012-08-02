This is a prototype application to demonstrate the following:

- Kendo UI
- Abstracted CQRS in Controllers
- Modularity
- Org Chart

## Modularity

This project demonstrates modularity in 2 ways.

The first is with the Module area. This area and its HTML artifacts are defined in the Web application, but the supporting classes are in the Module project. The controllers are discovered with a custom controller factory named MyControllerFactory.

The second is with the OtherModule area. This area has been created as a separate MVC project named OtherModule and referenced by the Web project. This allows *all* HTML, Scripts, Controllers, etc. to be defined in the module's project. For this to work, you must add OtherModules as a virtual directory. To do this in IIS Express either:

1. Modifying the application defintion in applicationhost.config to include:
<pre><code>
<virtualDirectory path="/Areas/OtherModule" physicalPath="<physical_path>" />
</code></pre>
2. Running IIS Express' appcmd.exe as follows:
<pre><code>
appcmd.exe add vdir /app.name:<appname> /path:/Areas/OtherModule /physicalPath:<physical_path>
</code></pre>

## Org Chart

Go to /Home/OrgChart. This page has an organisational chart control (jQuery Org Chart - https://github.com/wesnolte/jOrgChart) that has been enabled for:

1. Drag and drop of items in the chart
2. Dragging items from another list into the chart
3. Disabling an item and all its children using a checkbox
