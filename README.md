# Vantage Class Library

### What Is this?
This project is a C# class library that intends to allow a developer to easily interface with Telestream's Vantage product. For more info head over to http://telestream.net.

This project is not sponsored by or endorsed by Telestream. I'm using the same Vantage API documentation available to anyone who inquires.

The libray is written using C# and .NET8. I used the Vantage Rest API version 5.4 which ships with Vantage version 8.1. In general this *should* work with previous versions of Vantage. That being said, YMMV if you're using a version of Vantage other than 8.1

### Warning

This is a mess and probably barely works. It's not ready for any sort of production use. Please plan that there will be breaking changes for some time. Feel free to tinker if that's your thing.

### Releases
Not yet. See above.

### Using the Library
The library should be at least somewhat discoverable on its own with some documentation on each function (see punch list below). Here's a sample to get you started.
````csharp
using VantageLibrary;
using VantageLibrary.Types;

static void Main(string[] args)
{
    // Pass in the base URL to your vantage system as a URI
    DomainClient domainClient = new DomainClient(new Uri("http://10.10.10.10:8676"));

    // Check if the domain is online?
    bool online = domainClient.Functions.DomainOnline();

    // Use the client
    List<VantageWorkflow> workflows = domainClient.Functions.GetWorkflows()
    
    foreach(var workflow in workflows){
        Console.WriteLine(workflow.Name);
    }

    // Always dispose of the client when done.
    domainClient.Dispose()
}

````

### Collaboration
Please feel free to open an issue I'll do my best to address it. Alternatively, I'd welcome any pull request if you'd care to contribute.

### Testing
There is a desktop client application that implements the library here:
https://github.com/devjt2/VantageClient

### Punch List
1. I've only really implemented all of the GET functions and a WorkflowSubmit POST function. PATCH, PUT, DELETE are still needed. See list below.
2. Complete documentation on all of the methods.
3. Need to add so much exception handling. I mean, it's insane that they let me write code at all.
4. Test all of the methods. I've written them out as best as I can so they compile. That doesn't mean I've tested everthing.



| Endpoint                            | Method | Description                                                                                                                                                                                 | Type Complete | Type Name             | Method Complete |
| ----------------------------------- | ------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------- | --------------------- | --------------- |
| /Binder/{id}                        | GET    | Gets a specific Binder for the domain.                                                                                                                                                      | TRUE          | VantageBinder         | TRUE            |
| /Binder/{id}/Content                | GET    | Gets the content for a specific Binder.                                                                                                                                                     | TRUE          | VantageContent        | TRUE            |
| /Catalogs                           | GET    | Gets all of the Catalog(s) for the domain.                                                                                                                                                  | TRUE          | VantageCatalogs       | TRUE            |
| /Catalogs/{id}                      | GET    | Gets a specific catalog for the domain.                                                                                                                                                     | TRUE          | VantageCatalog        | TRUE            |
| /Catalogs/Cleanup                   | POST   | Clean up (remove from Vantage) all folders which are marked as Transient and are empty.                                                                                                     |               |                       |                 |
| /Category/{name}/Create             | PUT    | Create a category with the specified name.                                                                                                                                                  |               |                       |                 |
| /Category/{name}/Exists             | GET    | Returns an indication of whether the Category with the provided name exists in this domain.                                                                                                 | TRUE          | N/A                   | TRUE            |
| /Content/{id}/Entries               | GET    | Return all outputs (Media Nicknames, Attachments and/or Labels) associated with a specific content.                                                                                         | TRUE          | VantageContentEntries | TRUE            |
| /Domain/Categories                  | GET    | Gets all categories from this domain.                                                                                                                                                       | TRUE          | VantageCategories     | TRUE            |
| /Domain/Load/{criteria}             | GET    | Gets the load for the Vantage domain based upon the provided criteria, eg:  /Domain/Load/CPU                                                                                                | TRUE          | VantageDomainLoad     | TRUE            |
| /Domain/Online                      | GET    | Returns an indication as to whether the SDK service has successfully attached to the domain database.                                                                                       | TRUE          | N/A                   | TRUE            |
| /Domain/Version                     | GET    | Returns a string representation of the version of the current Vantage domain (eg: 7.0.0.0).                                                                                                 | TRUE          | VantageDomainVersion  | TRUE            |
| /Folder/{id}                        | GET    | Gets a specific Folder for the domain.                                                                                                                                                      | TRUE          | VantageFolder         | TRUE            |
| /Folders/{id}                       | GET    | Gets all of the Folder(s) for a given Catalog or Folder.                                                                                                                                    | TRUE          | VantageFolders        | TRUE            |
| /Folders/{id}/Binder/{name}         | GET    | Gets a Binder in a specific Catalog or Folder by Binder Name.                                                                                                                               | TRUE          | VantageBinder         | TRUE            |
| /Folders/{id}/Binders               | GET    | Gets all of the Binder(s) for a given Catalog or Folder.                                                                                                                                    | TRUE          | VantageBinders        | TRUE            |
| /Jobs/{id}                          | GET    | Returns information about the job with the provided identifier.                                                                                                                             | TRUE          | VantageJob            | TRUE            |
| /Jobs/{id}/Actions                  | GET    | Return all actions associated with a specific job.                                                                                                                                          | TRUE          | VantageActions        | TRUE            |
| /Jobs/{id}/ErrorMessage             | GET    | Returns the relevant error message associated with a job which has failed.                                                                                                                  | TRUE          | VantageErrorMessage   | TRUE            |
| /Jobs/{id}/Forwarded                | GET    | Returns a collection of jobs which were created as a result of being forwarded from the specified job.                                                                                      | FALSE         |                       | FALSE           |
| /Jobs/{id}/Metrics                  | GET    | Return specific metrics (eg: total  run time, total queue time) about a specified job.                                                                                                      | TRUE          | VantageJobMetric      | TRUE            |
| /Jobs/{id}/Outputs                  | GET    | Return all outputs (Media Nicknames, Attachments and/or Labels) associated with a specific job.                                                                                             | TRUE          | VantageJobOutput      | TRUE            |
| /Jobs/{id}/Progress                 | GET    | Returns the progress (percent complete) for the specified job.                                                                                                                              | TRUE          | VantageJobProgress    | TRUE            |
| /Jobs/{id}/Remove                   | DELETE | Removes a completed job with the specified identifier.                                                                                                                                      | FALSE         |                       |                 |
| /Jobs/{id}/Restart                  | PUT    | Restarts a job which has previously been stopped.  Only a job that is in the Stopped By User state may be restarted.                                                                        | FALSE         |                       |                 |
| /Jobs/{id}/Stop                     | PUT    | Stops the job identified by the provided identifier.                                                                                                                                        | FALSE         |                       |                 |
| /Machines                           | GET    | Return all machines in the domain.                                                                                                                                                          | TRUE          | VantageMachines       | TRUE            |
| /Machines/{id}/Preshutdown          | POST   | Instruct all services on the specified machine to begin the preshutdown state.                                                                                                              | FALSE         |                       |                 |
| /Services                           | GET    | Get all online services present in this Vantage domain.                                                                                                                                     | TRUE          | VantageServices       | TRUE            |
| /Services/{id}/Metrics              | GET    | Gets the metric information associated with the specified service.                                                                                                                          | TRUE          | VantageServiceMetrics | TRUE            |
| /Services/{id}/Preshutdown          | POST   | Request that the specified service enter the preshutdown state.                                                                                                                             | FALSE         |                       |                 |
| /Services/LookupHosting             | GET    | Returns information about services hosting actions of the specified type.  'actionType' may be: Capture, Tape, Subclip, Watch, Workorder, Camera, Catch, Dublist or Asset .                 | TRUE          | VantageServices       | TRUE            |
| /Services/SearchByMachine/{machine} | GET    | Gets all online services in the domain which reside on the specified machine.                                                                                                               | TRUE          | VantageServices       | TRUE            |
| /Stores                             | GET    | Returns information about Vantage Managed Stores.  An optional qualifier which indicates whether to include offline Stores is avaialble as well.                                            | TRUE          | VantageStores         | TRUE            |
| /Stores/{id}                        | GET    | Return information about the specified Vantage Managed Store.                                                                                                                               | TRUE          | VantageStore          | TRUE            |
| /Stores/{id}/InUse                  | GET    | Return information about the specified Vantage Managed Store including whether or not the Vantage Managed Store is currently being utilized.                                                | TRUE          | VantageStoreInUse     | TRUE            |
| /Workflows                          | GET    | Gets all of the vantage workflows for this domain.                                                                                                                                          | TRUE          | VantageWorkflows      | TRUE            |
| /Workflows/{id}                     | GET    | Gets the workflow with the specified identifier from this domain.                                                                                                                           | TRUE          | VantageWorkflow       | TRUE            |
| /Workflows/{id}/Activate            | PUT    | Activate the specified workflow.                                                                                                                                                            | FALSE         |                       |                 |
| /Workflows/{id}/Deactivate          | PUT    | Deactivate the specified workflow.                                                                                                                                                          | FALSE         |                       |                 |
| /Workflows/{id}/Export              | GET    | Obtain a compressed representation of the specified workflow.                                                                                                                               | TRUE          | VantageWorkflowExport | TRUE            |
| /Workflows/{id}/JobInputs           | GET    | Gets the inputs which may be submitted to the workflow with the specified identifier.                                                                                                       | TRUE          | VantageJobInputs      | TRUE            |
| /Workflows/{id}/Jobs/               | GET    | Return all jobs for a specified workflow which match the specified filter criteria.  The valid values for the filter query parameter are: 'All', 'Active', 'Failed', 'Paused' or 'Complete' | TRUE          | VantageJobs           | TRUE            |
| /Workflows/{id}/Rename              | PUT    | Renames the specified workflow to a new name.                                                                                                                                               | FALSE         |                       |                 |
| /Workflows/{id}/Signature           | GET    | Obtain a value representing a unique signature for a workflow.                                                                                                                              | TRUE          |                       |                 |
| /Workflows/{id}/Submit              | POST   | Submit a job to a workflow.   The request data should be obtained via the /Workflows/{ID}/JobInputs GET query.                                                                              | TRUE          | VantageJobInput       | FALSE           |
| /Workflows/{id}/SubmitBinder        | POST   | Submit a Binder to a workflow.                                                                                                                                                              | FALSE         |                       | FALSE           |
| /Workflows/ExportToPath             | POST   | Create a new XML representation of a workflow at the specified path.                                                                                                                        | FALSE         |                       | FALSE           |
| /Workflows/Import                   | PUT    | Import a workflow which had been previously exported from a Domain.                                                                                                                         | FALSE         |                       | FALSE           |
| /Workflows/ImportFromPath           | PUT    | Import a workflow specified by a file path.                                                                                                                                                 | FALSE         |                       | FALSE           |
| /Workflows/Synchronize              | PUT    | Synchronizes a workflow with a new definition from a specified file path.                                                                                                                   | FALSE         |                       | FALSE           |

