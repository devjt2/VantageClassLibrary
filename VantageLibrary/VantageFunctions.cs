using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VantageLibrary.Types;
using System.Diagnostics;
using VantageLibrary.Types.InternalTypes;
using VantageLibrary.Types.RequestTypes;
using VantageLibrary.Types.ResponseTypes;
using VantageLibrary.WebRequests;
using VantageLibrary.Enums;

namespace VantageLibrary
{
    public class VantageFunctions : IDisposable
    {
        private readonly BaseWebRequests _webRequests;

        public VantageFunctions(Uri baseAddress) {
            _webRequests = new BaseWebRequests(baseAddress);
        }
        #region GET_Requests
        /// <summary>
        /// Gets a specific Binder for the domain.
        /// </summary>
        /// <param name="binderId"></param>
        /// <returns>VantageBinder</returns>
        public VantageBinder GetBinder(Guid binderId)
        {
            VantageBinderWrapper vantageBinder = Utilities.Serialization.Deserialize<VantageBinderWrapper>(_webRequests.VantageRestGet("/Rest/Binder/" + binderId.ToString()));
            return vantageBinder.Binder;
        }

        /// <summary>
        /// Gets the content for a specific Binder.
        /// Reference for http://10.3.3.238:8676/Rest/Binder/{ID}/Content
        /// </summary>
        /// <param name="binderId"></param>
        /// <returns></returns>
        public VantageBinderContent GetBinderContent(Guid binderId)
        {
            VantageBinderContent vantageBinderContent = Utilities.Serialization.Deserialize<VantageBinderContent>(_webRequests.VantageRestGet("/Rest/Binder/" + binderId.ToString() + "/Content"));
            return vantageBinderContent;
        }

        /// <summary>
        /// Gets all of the Catalog(s) for the domain.
        /// </summary>
        /// <returns></returns>
        public List<VantageCatalog> GetVantageCatalogs()
        {
            VantageCatalogs catalogs = Utilities.Serialization.Deserialize<VantageCatalogs>(_webRequests.VantageRestGet("/Rest/Catalogs"));
            return catalogs.Catalogs;
        }

        /// <summary>
        /// Gets a specific catalog for the domain.
        /// </summary>
        /// <param name="catalogId"></param>
        /// <returns></returns>
        public VantageCatalog GetCatalog(Guid catalogId)
        {
            VantageCatalogWrapper catalog = Utilities.Serialization.Deserialize<VantageCatalogWrapper>(_webRequests.VantageRestGet("/Rest/Catalogs/" + catalogId));
            return catalog.Catalog;
        }

        public bool CategoryExists(string categoryName)
        {
            VantageCategoryExists categoryExists = Utilities.Serialization.Deserialize<VantageCategoryExists>(_webRequests.VantageRestGet("/Rest/Category/" + categoryName + "/Exists"));
            return categoryExists.CategoryExists;
        }

        /// <summary>
        /// Return all outputs (Media Nicknames, Attachments and/or Labels) associated with a specific content.
        /// </summary>
        /// <param name="contentId"></param>
        /// <returns></returns>
        public VantageContentEntries GetContentEntries(Guid contentId)
        {
            VantageContentEntries vantageContentEntries = Utilities.Serialization.Deserialize<VantageContentEntries>(_webRequests.VantageRestGet("/Rest/Content/" + contentId.ToString() + "/Entries"));
            return vantageContentEntries;
        }

        /// <summary>
        /// Gets all categories from this domain.
        /// </summary>
        /// <returns></returns>
        public List<VantageCategory> GetCategories()
        {
            var categories = Utilities.Serialization.Deserialize<VantageCategories>(_webRequests.VantageRestGet("/Rest/Domain/Categories"));
            return categories.Categories;
        }

        /// <summary>
        /// Returns an int value of the domain load across all machines.
        /// </summary>
        /// <param name="criteria">I think we can declare 'CPU' or 'GPU' unsure? Defaults to CPU.</param>
        /// <returns>int</returns>
        public int GetDomainLoad(string criteria = "CPU")
        {
            var domainLoad = Utilities.Serialization.Deserialize<VantageDomainLoad>(_webRequests.VantageRestGet("/Rest/Domain/Load/" + criteria));
            return domainLoad.Load;
        }

        public bool DomainOnline()
        {
            VantageDomainOnline domainOnline;
            try
            {
                domainOnline = Utilities.Serialization.Deserialize<VantageDomainOnline>(_webRequests.VantageRestGet("/Rest/Domain/Online"));
                return domainOnline.Online;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the vantage domain version.
        /// </summary>
        /// <returns>string</returns>
        public string DomainVersion()
        {
            VantageDomainVersion domainVersion = Utilities.Serialization.Deserialize<VantageDomainVersion>(_webRequests.VantageRestGet("/Rest/Domain/Version"));
            return domainVersion.Version;
        }

        /// <summary>
        /// Gets a specific Folder for the domain.
        /// </summary>
        /// <param name="folderId"></param>
        /// <returns>VantageFolder</returns>
        public VantageFolder GetFolder(Guid folderId)
        {
            VantageFolderWrapper vantageFolder = Utilities.Serialization.Deserialize<VantageFolderWrapper>(_webRequests.VantageRestGet("/Rest/Domain/Version"));
            return vantageFolder.Folder;
        }

        /// <summary>
        /// Gets all vantage folders for a given Catalog or Folder
        /// </summary>
        /// <param name="folderId">This can be a catalog or folder id</param>
        /// <returns>A List&lt;VantageFolder&gt; Object</returns>
        public List<VantageFolder> GetFolders(Guid folderId)
        {
            VantageFolders vantageFolders = Utilities.Serialization.Deserialize<VantageFolders>(_webRequests.VantageRestGet("/Rest/Domain/Version"));
            return vantageFolders.Folders;
        }

        /// <summary>
        /// Gets a Binder in a specific Catalog or Folder by Binder Name.
        /// </summary>
        /// <param name="folderId">This can be a folder or catalog id</param>
        /// <param name="binderName"></param>
        /// <returns></returns>
        public VantageBinder GetBinderByName(Guid folderId, string binderName)
        {
            VantageBinderWrapper vantageBinder = Utilities.Serialization.Deserialize<VantageBinderWrapper>(_webRequests.VantageRestGet("/Rest/Folders/" + folderId + "/Binder" + binderName));
            return vantageBinder.Binder;
        }

        /// <summary>
        /// Gets all of the Binder(s) for a given Catalog or Folder.
        /// </summary>
        /// <param name="folderId">This can be a folder or catalog id</param>
        /// <param name="binderName"></param>
        /// <returns></returns>
        public List<VantageBinder> GetBindersByFolderOrCatalog(Guid folderId, string binderName)
        {
            VantageBinders vantageBinders = Utilities.Serialization.Deserialize<VantageBinders>(_webRequests.VantageRestGet("/Rest/Folders/" + folderId + "/Binders"));
            return vantageBinders.Binders;
        }

        /// <summary>
        /// Returns information about the job with the provided identifier.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns>VantageJob</returns>
        public VantageJob GetJob(Guid jobId)
        {
            VantageJobWrapper vantageJob = Utilities.Serialization.Deserialize<VantageJobWrapper>(_webRequests.VantageRestGet("/Rest/Jobs/" + jobId));
            return vantageJob.Job;
        }

        /// <summary>
        /// Return all actions associated with a specific job.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns>List&lt;VantageJobAction&gt;</returns>
        public List<VantageJobAction> GetJobActions(Guid jobId)
        {
            VantageJobActions vantageJobActions = Utilities.Serialization.Deserialize<VantageJobActions>(_webRequests.VantageRestGet("/Rest/Jobs/" + jobId + "/Actions"));
            return vantageJobActions.Actions;
        }

        /// <summary>
        /// Returns the relevant error message associated with a job which has failed.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns>string</returns>
        public string GetJobErrorMessage(Guid jobId)
        {
            VantageJobErrorMessage vantageJobErrorMessage = Utilities.Serialization.Deserialize<VantageJobErrorMessage>(_webRequests.VantageRestGet("/Rest/Jobs/" + jobId + "/ErrorMessage"));
            return vantageJobErrorMessage.JobErrorMessage;
        }

        /// <summary>
        /// Returns a collection of jobs which were created as a result of being forwarded from the specified job.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns>List&lt;VantageJob&gt;</returns>
        public List<VantageJob> GetJobForwards(Guid jobId)
        {
            VantageJobs vantageJobs = Utilities.Serialization.Deserialize<VantageJobs>(_webRequests.VantageRestGet("/Rest/Jobs/" + jobId + "/Forwarded"));
            return vantageJobs.Jobs;
        }

        /// <summary>
        /// Return specific metrics (eg: total  run time, total queue time) about a specified job.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns>VantageJobMetric</returns>
        public VantageJobMetric GetJobMetrics(Guid jobId)
        {
            VantageJobMetric vantageJobMetric = Utilities.Serialization.Deserialize<VantageJobMetric>(_webRequests.VantageRestGet("/Rest/Jobs/" + jobId));
            return vantageJobMetric;
        }

        /// <summary>
        /// Return all outputs (Media Nicknames, Attachments and/or Labels) associated with a specific job.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns>VantageJobOutput</returns>
        public VantageJobOutput GetJobOutputs(Guid jobId)
        {
            VantageJobOutput vantageJobOutput = Utilities.Serialization.Deserialize<VantageJobOutput>(_webRequests.VantageRestGet("/Rest/Jobs/" + jobId + "/Outputs"));
            return vantageJobOutput;
        }

        /// <summary>
        /// Returns the progress (percent complete) for the specified job.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns>int</returns>
        public int GetJobProgress(Guid jobId)
        {
            VantageJobProgress vantageJobProgress = Utilities.Serialization.Deserialize<VantageJobProgress>(_webRequests.VantageRestGet("/Rest/Jobs/" + jobId + "/Progress"));
            return vantageJobProgress.JobProgress;
        }

        /// <summary>
        /// Return all machines in the domain.
        /// </summary>
        /// <returns>List&lt;VantageMachine&gt;</returns>
        public List<VantageMachine> GetMachines()
        {
            VantageMachines vantageMachines = Utilities.Serialization.Deserialize<VantageMachines>(_webRequests.VantageRestGet("/Rest/Machines"));
            return vantageMachines.Machines;
        }

        /// <summary>
        /// Return all machines in the domain.
        /// </summary>
        /// <returns>List&lt;VantageService&gt;</returns>
        public List<VantageService> GetServices()
        {
            VantageServices vantageServices = Utilities.Serialization.Deserialize<VantageServices>(_webRequests.VantageRestGet("/Rest/Services"));
            return vantageServices.Services;
        }

        /// <summary>
        /// Gets the metric information associated with the specified service.
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns>VantageServiceMetric.ServiceMetric</returns>
        public VantageServiceMetric.ServiceMetric GetServiceMetric(Guid serviceId)
        {
            VantageServiceMetric vantageServiceMetrics = Utilities.Serialization.Deserialize<VantageServiceMetric>(_webRequests.VantageRestGet("/Rest/Services/" + serviceId + "/Metrics"));
            return vantageServiceMetrics.Metric;
        }

        /// <summary>
        /// Returns information about services hosting actions of the specified type. 'actionType' may be: Capture, Tape, Subclip, Watch, Workorder, Camera, Catch, Dublist or Asset .
        /// </summary>
        /// <param name="actionType"></param>
        /// <returns>List&lt;VantageService&gt;</returns>
        public List<VantageService> GetServicesLookupHosting(ActionTypes actionType)
        {
            VantageServices vantageServices = Utilities.Serialization.Deserialize<VantageServices>(_webRequests.VantageRestGet("/Rest/Services/LookupHosting?Type=" + actionType.ToString()));
            return vantageServices.Services;
        }

        /// <summary>
        /// Gets all online services in the domain which reside on the specified machine.
        /// </summary>
        /// <param name="machineId"></param>
        /// <returns>List&lt;VantageService&gt;</returns>
        public List<VantageService> GetServicesByMachine(Guid machineId)
        {
            VantageServices vantageServices = Utilities.Serialization.Deserialize<VantageServices>(_webRequests.VantageRestGet("/Rest/Services/SearchByMachine/" + machineId));
            return vantageServices.Services;
        }

        /// <summary>
        /// Returns information about Vantage Managed Stores. An optional qualifier which indicates whether to include offline Stores is avaialble as well.
        /// </summary>
        /// 
        /// <returns>List&lt;VantageStore&gt;</VantageStore></returns>
        public List<VantageStore> GetStores()
        {
            VantageStores vantageStores = Utilities.Serialization.Deserialize<VantageStores>(_webRequests.VantageRestGet("/Rest/Stores"));
            return vantageStores.Stores;
        }

        /// <summary>
        /// Return information about the specified Vantage Managed Store.
        /// </summary>
        /// <param name="vantageStoreId"></param>
        /// <returns>VantageStore</returns>
        public VantageStore GetStore(Guid vantageStoreId)
        {
            VantageStoreWrapper vantageStoreWrapper = Utilities.Serialization.Deserialize<VantageStoreWrapper>(_webRequests.VantageRestGet("/Rest/Stores" + vantageStoreId));
            return vantageStoreWrapper.Store;
        }

        /// <summary>
        /// Return information about the specified Vantage Managed Store including whether or not the Vantage Managed Store is currently being utilized.
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns>Boolean</returns>
        public bool GetStoreInUse(Guid storeId)
        {
            VantageStoreInUse storeInUse = Utilities.Serialization.Deserialize<VantageStoreInUse>(_webRequests.VantageRestGet("/Rest/Stores/" + storeId.ToString() + "/InUse"));
            return storeInUse.StoreInUse;
        }

        /// <summary>
        /// Gets all of the vantage workflows for this domain.
        /// </summary>
        /// <returns></returns>
        public List<VantageWorkflow> GetWorkflows()
        {
            VantageWorkflows workflows = Utilities.Serialization.Deserialize<VantageWorkflows>(_webRequests.VantageRestGet("/Rest/Workflows"));
            return workflows.Workflows;
        }

        /// <summary>
        /// Gets the workflow with the specified identifier from this domain.
        /// </summary>
        /// <param name="vantageWorkflowId"></param>
        /// <returns></returns>
        public VantageWorkflow GetWorkflow(Guid vantageWorkflowId)
        {
            VantageWorkflowWrapper workflow = Utilities.Serialization.Deserialize<VantageWorkflowWrapper>(_webRequests.VantageRestGet("/Rest/Workflows/" + vantageWorkflowId));
            return workflow.Workflow;
        }

        /// <summary>
        /// Return all jobs for a specified workflow which match the specified filter criteria.
        /// The valid values for the filter query parameter are: 'All', 'Active', 'Failed', 'Paused' or 'Complete'
        /// Reference for http://10.3.3.238:8676/Rest/Workflows/{ID}/Jobs/?filter={FILTER}
        /// <param name="workflowId"></param>
        /// <param name="jobsFilter"></param>
        /// <returns>A list of Vantage jobs from a specific workflow that match the filter.</returns>
        /// 
        public List<VantageJob> GetWorkflowJobs(Guid workflowId, JobsFilterEnum? jobsFilter = JobsFilterEnum.All)
        {
            VantageJobs vantageJobs = Utilities.Serialization.Deserialize<VantageJobs>(_webRequests.VantageRestGet("/Rest/Workflows/" + workflowId + "/Jobs?filter=" + jobsFilter.ToString()));
            return vantageJobs.Jobs;
        }

        /// <summary>
        /// Gets the inputs which may be submitted to the workflow with the specified identifier.
        /// </summary>
        /// <param name="vantageWorkflowId"></param>
        /// <returns>A VantageWorkflowJobInputs object that instructs what inputs are valid for a specific workflow.</returns>
        public VantageWorkflowJobInputs GetWorkflowJobInputs(Guid vantageWorkflowId)
        {
            VantageWorkflowJobInputs workflow = Utilities.Serialization.Deserialize<VantageWorkflowJobInputs>(_webRequests.VantageRestGet("/Rest/Workflows/" + vantageWorkflowId + "/JobInputs"));
            return workflow;
        }

        /// <summary>
        /// Obtain a compressed representation of the specified workflow. Use caution with this method as it will return a string of many megabytes depending on size of the authored workflow.
        /// </summary>
        /// <param name="vantageWorkflowId"></param>
        /// <returns>Compressed data represented as string.</returns>
        public string GetCompressedWorkflow(Guid vantageWorkflowId)
        {
            VantageCompressedWorkflow workflow = Utilities.Serialization.Deserialize<VantageCompressedWorkflow>(_webRequests.VantageRestGet("/Rest/Workflows/" + vantageWorkflowId + "/Export"));
            return workflow.CompressedWorkflow;
        }
        #endregion

        #region POST_Requests
        /// <summary>
        /// Submits a job into a Vantage workflow.
        /// </summary>
        /// <param name="vantageWorkflowId"></param>
        /// <param name="job"></param>
        /// <returns>Guid ID of the started job.</returns>
        public Guid SubmitJob(Guid vantageWorkflowId, VantageWorkflowJobInputs job)
        {
            string vantageJobResponse = String.Empty;
            try
            {
                vantageJobResponse = _webRequests.VantageRestPostAsync<VantageWorkflowJobInputs>("/Rest/Workflows/" + vantageWorkflowId + "/Submit", job);;
            }
            
            catch (Exception ex){ 
                string innerException = ex.InnerException.Message;
            }
            WorkflowSubmitResponse vantageJob = Utilities.Serialization.Deserialize<WorkflowSubmitResponse>(vantageJobResponse);
            return vantageJob.JobIdentifier;
        }

        /// <summary>
        /// Create a new XML representation of a workflow at the specified path.
        /// </summary>
        /// <param name="export">This is the data object with the job request and should include the workflow to export as well as a path where to export it.</param>
        /// <returns>FileInfo</returns>
        /// <exception cref="Exception"></exception>
        public FileInfo ExportWorkflow(VantageExportWorkflow export)
        {
            string exportedWorkflow;
            try
            {
                exportedWorkflow = _webRequests.VantageRestPostAsync<VantageExportWorkflow>("/Rest/Workflows/ExportToPath", export);
            }

            catch (Exception ex)
            {
                throw new Exception("Something went wrong.");
            }
            VantageExportedWorkflow exportedWorkflowObj = Utilities.Serialization.Deserialize<VantageExportedWorkflow>(exportedWorkflow);
            return exportedWorkflowObj.PathToExportedFile;
        }

        /// <summary>
        /// Clean up (remove from Vantage) all folders which are marked as Transient and are empty.
        /// </summary>
        /// <returns>bool</returns>
        public bool CleanupCatalogs()
        {
            bool cleanup = _webRequests.VantageRestPostAsync("/Rest/Catalogs/Cleanup");
            return cleanup;
        }

        /// <summary>
        /// Instruct all services on the specified machine to begin the preshutdown state.
        /// Url: http://10.3.3.238:8676/Rest/Machines/{ID}/Preshutdown
        /// </summary>
        /// <param name="vantageMachineId"></param>
        /// <returns>bool</returns>
        public bool MachinePreShutdown(Guid vantageMachineId)
        {
            bool preShutdown = _webRequests.VantageRestPostAsync("/Rest/Machines/" + vantageMachineId + "/Preshutdown");
            return preShutdown;
        }

        /// <summary>
        /// Request that the specified service enter the preshutdown state.
        /// </summary>
        /// <param name="vantageServiceId"></param>
        /// <returns>bool</returns>
        public bool ServicePreShutdown(Guid vantageServiceId)
        {
            bool preShutdown = _webRequests.VantageRestPostAsync("/Rest/Services/" + vantageServiceId + "/Preshutdown");
            return preShutdown;
        }
        #endregion

        #region DELETE_Requests
        /// <summary>
        /// Removes a completed job with the specified identifier.
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public bool RemoveJob(Guid jobId)
        {
            //TODO: do this
            bool deleted = _webRequests.VantageRestDelete("/Rest/Jobs/" + jobId);

            return deleted;
        }
        #endregion

        #region PUT_Requests

        /// <summary>
        /// Create a category with the specified name.
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public VantageCategory CreateCategory(string categoryName)
        {
            string categoryCreationResponse = _webRequests.VantageRestPut<string>("/Rest/Category/" + categoryName + "/Create");
            VantageCategoryWrapper resultCategoryWrapper = Utilities.Serialization.Deserialize<VantageCategoryWrapper>(categoryCreationResponse);
            return resultCategoryWrapper.Category;
        }
        //VantageRestartJobSuccessful  http://10.3.3.238:8676/Rest/Jobs/{ID}/Restart
        /// <summary>
        /// Restarts a job which has previously been stopped. Only a job that is in the Stopped By User state may be restarted.
        /// </summary>
        /// <param name="jobId">Job ID of the job that you want to restart.</param>
        /// <returns>bool</returns>
        public bool RestartWorkflowJob(Guid jobId)
        {
            return _webRequests.VantageRestPut<bool>("/Rest/Jobs/" + jobId + "/Restart");
        }
        /// <summary>
        /// Stops the job identified by the provided identifier.
        /// </summary>
        /// <param name="jobId">Job ID of the job that you want to stop.</param>
        /// <returns>bool</returns>
        public bool StopWorkflowJob(Guid jobId)
        {
            return _webRequests.VantageRestPut<bool>("/Rest/Jobs/" + jobId + "/Stop");
        }

        /// <summary>
        /// Activate the specified workflow.
        /// </summary>
        /// <param name="workflowId"></param>
        /// <returns></returns>
        public bool ActivateWorkflow(Guid workflowId)
        {
            return _webRequests.VantageRestPut<bool>("/Rest/Workflows/" + workflowId + "/Activate");
        }
        /// <summary>
        /// Deactivate the specified workflow.
        /// </summary>
        /// <param name="workflowId"></param>
        /// <returns></returns>
        public bool DeactivateWorkflow(Guid workflowId)
        {
            return _webRequests.VantageRestPut<bool>("/Rest/Workflows/" + workflowId + "/Deactivate");
        }
        /// <summary>
        /// Renames the specified workflow to a new name.
        /// </summary>
        /// <param name="workflowId"></param>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public bool RenameWorkflow(Guid workflowId, NewWorkflowName obj)
        {
            string renameSuccess = _webRequests.VantageRestPut<NewWorkflowName>("/Rest/Workflows/" + workflowId + "/Rename", obj);
            VantageWorkflowRenameSuccess success = Utilities.Serialization.Deserialize<VantageWorkflowRenameSuccess>(renameSuccess);
            return success.Success;
        }
        /// <summary>
        /// Import a compressed workflow which had been previously exported from a Domain.
        /// </summary>
        /// <param name="compressedWorkflowData">The compressed workflow data as string.</param>
        /// <returns>Guid</returns>
        public Guid ImportCompressedWorkflow(string compressedWorkflowData)
        {
            ImportCompressedWorkflow compressedWf = new ImportCompressedWorkflow { 
                CompressedWorkflow = compressedWorkflowData
            };
            string wfImportResponse = _webRequests.VantageRestPut<ImportCompressedWorkflow>("/Rest/Workflows/Import", compressedWf);
            VantageWorkflowIdResponse workflowId = Utilities.Serialization.Deserialize<VantageWorkflowIdResponse>(wfImportResponse);
            return workflowId.WorkflowIdentifier;
        }
        /// <summary>
        /// Import a workflow specified by a file path.
        /// </summary>
        /// <param name="importWorkflowFromFileObj">Object of type ImportWorkflowFromFile</param>
        /// <returns>Guid</returns>
        public Guid ImportWorkflowFromPath(ImportWorkflowFromFile importWorkflowFromFileObj)
        {
            string wfImportResponse = _webRequests.VantageRestPut<ImportWorkflowFromFile>("/Rest/Workflows/ImportFromPath", importWorkflowFromFileObj);
            VantageWorkflowIdResponse workflowId = Utilities.Serialization.Deserialize<VantageWorkflowIdResponse>(wfImportResponse);
            return workflowId.WorkflowIdentifier;
        }

        /// <summary>
        /// Synchronizes a workflow with a new definition from a specified file path.
        /// </summary>
        /// <param name="synchronizeWorkflowFromFileObj"></param>
        /// <returns>Guid</returns>
        public Guid SynchronizeWorkflowFromFile(SynchronizeWorkflowFromFile synchronizeWorkflowFromFileObj)
        {
            string wfUpdateResponse = _webRequests.VantageRestPut<SynchronizeWorkflowFromFile>("/Rest/Workflows/Synchronize", synchronizeWorkflowFromFileObj);
            VantageWorkflowIdResponse workflowId = Utilities.Serialization.Deserialize<VantageWorkflowIdResponse>(wfUpdateResponse);
            return workflowId.WorkflowIdentifier;
        }

        #endregion

        /// <summary>
        /// Disposes the downstream webrequests.
        /// </summary>
        public void Dispose()
        {
            _webRequests.Dispose();
        }
    }
}
