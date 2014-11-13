#Datasource location extensions#

This *hack* will allow you to use Sitecore query in the *datasource location* field of a component. In addition it will also allow you to define multiple templates allowed for selection, or disable the add new option even when selecting a template.

##Installation##
Add `Sitecore.Kernel.dll` to the lib folder, compile and copy the resulting DLL and config file in your solution.

##Usage##
Sitecore queries will be supported in the datasource location field of components. Queries are identified by prepending them with **query:** (just like it happens in field sources). You can also use relative paths directly, without creating a query, by just adding a path that starts with a dot **.** *e.g.* ./global 

Relative paths are resolved against the context item at the time of adding the datasource to a component.

The code also allows to enable/disable the add new content option in the select datasource dialog (independently of whether a template has been selected or not). Simply create a new field "allow create" as a checkbox in the template for component definition items.

You can also select multiple templates allowed for selection by adding another field "allowed templates" to the template for component definition items. If enabling the creation of new datasources the template used will be the one in the usual *datasource template* field. 