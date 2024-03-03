### Response types from Vantage. These *can*, but may not always, be returned to the consuming application. In the case where something can be simplified it will be. For example we would just return a boolean instead of an object containging a bool value.

### Notes
Getting a workflow object is different depending on the endpoint you call. Meaning if you call /Domain/Categories (GetCategories() method) you'll get a list of categories that each contain a list of workflows. However, these are only abridged versions of a full VantageWorkflow object. Because of this I've called the workflows contained in a VantageCategory object 'VantageCategoryWorkflow'.

Calling /Workflows/{ID} (GetWorkflow() method) will get you the full VantageWorkflow object.