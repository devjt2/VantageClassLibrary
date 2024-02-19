﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VantageLibrary;
using VantageLibrary.Types;
using System.Diagnostics;

namespace VantageLibrary {
    public class VantageFunctions : IDisposable
    {
        private readonly BaseWebRequests _webRequests;

        public VantageFunctions(Uri baseAddress) {
            _webRequests = new BaseWebRequests(baseAddress);
        }
        /// Starting with all of the GET requests.

        /// <summary>
        /// Gets a specific Binder for the domain.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="binderId"></param>
        /// <returns></returns>
        public VantageBinder GetBinder(Guid binderId)
        {
            VantageBinderWrapper vantageBinder = Utilities.Serialization.Deserialize<VantageBinderWrapper>(_webRequests.VantageRestGet("/Rest/Binder/" + binderId.ToString()));
            return vantageBinder.Binder;
        }
        /// <summary>
        /// Gets the content for a specific Binder.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="binderId"></param>
        /// <returns></returns>
        public VantageBinder GetBinderContent(Guid binderId)
        {
            VantageBinderWrapper vantageBinder = Utilities.Serialization.Deserialize<VantageBinderWrapper>(_webRequests.VantageRestGet("/Rest/Binder/" + binderId.ToString() + "/Content"));
            return vantageBinder.Binder;
        }
        /// <summary>
        /// Gets all of the Catalog(s) for the domain.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public List<VantageCatalog> GetVantageCatalogs()
        {
            VantageCatalogs catalogs = Utilities.Serialization.Deserialize<VantageCatalogs>(_webRequests.VantageRestGet("/Rest/Catalogs"));
            return catalogs.Catalogs;
        }
        /// <summary>
        /// Gets a specific catalog for the domain.
        /// </summary>
        /// <param name="client"></param>
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
        /// <param name="client"></param>
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
        /// <param name="client"></param>
        /// <returns></returns>
        public List<VantageCategory> GetCategories()
        {
            var categories = Utilities.Serialization.Deserialize<VantageCategories>(_webRequests.VantageRestGet("/Rest/Domain/Categories"));
            return categories.Categories;
        }

        /// <summary>
        /// Returns a long value of the domain load across all machines.
        /// </summary>
        /// <param name="criteria">I think we can declare 'CPU' or 'GPU' unsure</param>
        /// <returns>long</returns>
        public long GetDomainLoad(string criteria = "CPU")
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
        /// <param name="client"></param>
        /// <returns>string</returns>
        public string DomainVersion()
        {
            VantageDomainVersion domainVersion = Utilities.Serialization.Deserialize<VantageDomainVersion>(_webRequests.VantageRestGet("/Rest/Domain/Version"));
            return domainVersion.Version;
        }
        /// <summary>
        /// Gets a specific Folder for the domain.
        /// </summary>
        /// <param name="client"></param>
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
        /// <param name="client"></param>
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
        /// <param name="client"></param>
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
        /// <param name="client"></param>
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
        /// <param name="client"></param>
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
        /// <param name="client"></param>
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
        /// <param name="client"></param>
        /// <param name="jobId"></param>
        /// <returns>string</returns>
        public string GetJobErrorMessage(Guid jobId)
        {
            VantageJobErrorMessage vantageJobErrorMessage = Utilities.Serialization.Deserialize<VantageJobErrorMessage>(_webRequests.VantageRestGet("/Rest/Jobs/" + jobId));
            return vantageJobErrorMessage.JobErrorMessage;
        }
        /// <summary>
        /// Returns a collection of jobs which were created as a result of being forwarded from the specified job.
        /// </summary>
        /// <param name="client"></param>
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
        /// <param name="client"></param>
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
        /// <param name="client"></param>
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
        /// <param name="client"></param>
        /// <param name="jobId"></param>
        /// <returns>long</returns>
        public long GetJobProgress(Guid jobId)
        {
            VantageJobProgress vantageJobProgress = Utilities.Serialization.Deserialize<VantageJobProgress>(_webRequests.VantageRestGet("/Rest/Jobs/" + jobId + "/Progress"));
            return vantageJobProgress.JobProgress;
        }

        /// <summary>
        /// Return all machines in the domain.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>List&lt;VantageMachine&gt;</returns>
        public List<VantageMachine> GetMachines()
        {
            VantageMachines vantageMachines = Utilities.Serialization.Deserialize<VantageMachines>(_webRequests.VantageRestGet("/Rest/Machines"));
            return vantageMachines.Machines;
        }
        /// <summary>
        /// Return all machines in the domain.
        /// </summary>
        /// <param name="client"></param>
        /// <returns>List&lt;VantageService&gt;</returns>
        public List<VantageService> GetServices()
        {
            VantageServices vantageServices = Utilities.Serialization.Deserialize<VantageServices>(_webRequests.VantageRestGet("/Rest/Services"));
            return vantageServices.Services;
        }
        /// <summary>
        /// Gets the metric information associated with the specified service.
        /// </summary>
        /// <param name="client"></param>
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
        /// <param name="client"></param>
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
        /// <param name="client"></param>
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
        /// <param name="client"></param>
        /// <returns>List&lt;VantageStore&gt;</VantageStore></returns>
        public List<VantageStore> GetStores()
        {
            VantageStores vantageStores = Utilities.Serialization.Deserialize<VantageStores>(_webRequests.VantageRestGet("/Rest/Stores"));
            return vantageStores.Stores;
        }
        /// <summary>
        /// Return information about the specified Vantage Managed Store.
        /// </summary>
        /// <param name="client"></param>
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
        /// <param name="client"></param>
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
        /// <param name="client"></param>
        /// <returns></returns>
        public List<VantageWorkflow> GetWorkflows()
        {
            VantageWorkflows workflows = Utilities.Serialization.Deserialize<VantageWorkflows>(_webRequests.VantageRestGet("/Rest/Workflows"));
            return workflows.Workflows;
        }
        /// <summary>
        /// Gets the workflow with the specified identifier from this domain.
        /// </summary>
        /// <param name="client"></param>
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
        /// <param name="client"></param>
        /// <param name="vantageWorkflowId"></param>
        /// <returns></returns>
        public VantageWorkflowJobInputs GetWorkflowJobInputs(Guid vantageWorkflowId)
        {
            VantageWorkflowJobInputs workflow = Utilities.Serialization.Deserialize<VantageWorkflowJobInputs>(_webRequests.VantageRestGet("/Rest/Workflows/" + vantageWorkflowId + "/JobInputs"));
            return workflow;
        }

        /// <summary>
        /// Obtain a compressed representation of the specified workflow.
        /// </summary>
        /// <param name="client"></param>
        /// <param name="vantageWorkflowId"></param>
        /// <returns></returns>
        public string GetWorkflowExport(Guid vantageWorkflowId)
        {
            VantageWorkflowExport workflow = Utilities.Serialization.Deserialize<VantageWorkflowExport>(_webRequests.VantageRestGet("/Rest/Workflows/" + vantageWorkflowId));
            return workflow.CompressedWorkflow;
        }


        // POST Requests

        public Guid SubmitJob(Guid vantageWorkflowId, VantageJobInput job)
        {
            string vantageJobResponse = String.Empty;
            try
            {
                vantageJobResponse = _webRequests.VantageRestPostAsync<VantageJobInput>("/Rest/Workflows/" + vantageWorkflowId + "/Submit", job);//.Result;
            }
            
            catch (Exception ex){ 
                string innerException = ex.InnerException.Message;
            }
            WorkflowSubmitResponse vantageJob = Utilities.Serialization.Deserialize<WorkflowSubmitResponse>(vantageJobResponse);
            return vantageJob.JobIdentifier;
        }

        public void Dispose()
        {
            _webRequests.Dispose();
        }
    }
}