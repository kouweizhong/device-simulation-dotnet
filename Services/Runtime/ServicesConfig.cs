// Copyright (c) Microsoft. All rights reserved.

using System.IO;
using Microsoft.Azure.IoTSolutions.DeviceSimulation.Services.Storage;

namespace Microsoft.Azure.IoTSolutions.DeviceSimulation.Services.Runtime
{
    public interface IServicesConfig
    {
        string SeedTemplate { get; }
        string SeedTemplateFolder { get; }
        string DeviceModelsFolder { get; }
        string DeviceModelsScriptsFolder { get; }
        string IoTHubConnString { get; }
        string IoTHubImportStorageAccount { get; set; }
        uint? IoTHubSdkDeviceClientTimeout { get; set; }
        string StorageAdapterApiUrl { get; }
        int StorageAdapterApiTimeout { get; }
        string AzureManagementAdapterApiUrl { get; }
        int AzureManagementAdapterApiTimeout { get; }
        string AzureManagementAdapterApiVersion { get; }
        bool TwinReadWriteEnabled { get; }
        StorageConfig MainStorage { get; }
        StorageConfig NodesStorage { get; set; }
        StorageConfig SimulationsStorage { get; set; }
        StorageConfig DevicesStorage { get; set; }
        StorageConfig PartitionsStorage { get; set; }
        StorageConfig StatisticsStorage { get; set; }
        string DiagnosticsEndpointUrl { get; }
        string UserAgent { get; }
        bool DevelopmentMode { get; }
        bool DisableSimulationAgent { get; }
        bool DisablePartitioningAgent { get; }
        bool DisableSeedByTemplate { get; }
    }

    // TODO: test Windows/Linux folder separator
    //       https://github.com/Azure/device-simulation-dotnet/issues/84
    public class ServicesConfig : IServicesConfig
    {
        public const string USE_DEFAULT_IOTHUB = "default";

        private string stf;
        private string dtf;
        private string dtbf;
        private string ihf;

        public ServicesConfig()
        {
            this.stf = string.Empty;
            this.dtf = string.Empty;
            this.dtbf = string.Empty;
            this.ihf = string.Empty;

            // By default, disable debugging features
            this.DevelopmentMode = false;
            this.DisableSimulationAgent = false;
            this.DisablePartitioningAgent = false;
            this.DisableSeedByTemplate = false;
        }

        public string DeviceModelsFolder
        {
            get { return this.dtf; }
            set { this.dtf = this.NormalizePath(value); }
        }

        public string DeviceModelsScriptsFolder
        {
            get { return this.dtbf; }
            set { this.dtbf = this.NormalizePath(value); }
        }

        public string SeedTemplateFolder
        {
            get { return this.stf; }
            set { this.stf = this.NormalizePath(value); }
        }

        public string SeedTemplate { get; set; }

        public string IoTHubConnString { get; set; }

        public string IoTHubImportStorageAccount { get; set; }

        public uint? IoTHubSdkDeviceClientTimeout { get; set; }

        public string StorageAdapterApiUrl { get; set; }

        public int StorageAdapterApiTimeout { get; set; }

        public string AzureManagementAdapterApiUrl { get; set; }

        public int AzureManagementAdapterApiTimeout { get; set; }

        public string AzureManagementAdapterApiVersion { get; set; }

        public string DiagnosticsEndpointUrl { get; set; }

        public bool TwinReadWriteEnabled { get; set; }

        public StorageConfig MainStorage { get; set; }

        public StorageConfig NodesStorage { get; set; }

        public StorageConfig SimulationsStorage { get; set; }

        public StorageConfig DevicesStorage { get; set; }

        public StorageConfig PartitionsStorage { get; set; }

        public string UserAgent { get; set; }

        public bool DevelopmentMode { get; set; }

        public StorageConfig StatisticsStorage { get; set; }

        public bool DisableSimulationAgent { get; set; }

        public bool DisablePartitioningAgent { get; set; }

        public bool DisableSeedByTemplate { get; set; }

        private string NormalizePath(string path)
        {
            return path
                       .TrimEnd(Path.DirectorySeparatorChar)
                       .Replace(
                           Path.DirectorySeparatorChar + "." + Path.DirectorySeparatorChar,
                           Path.DirectorySeparatorChar.ToString())
                   + Path.DirectorySeparatorChar;
        }
    }
}
