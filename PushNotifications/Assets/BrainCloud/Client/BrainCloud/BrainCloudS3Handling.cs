//----------------------------------------------------
// brainCloud client source code
// Copyright 2016 bitHeads, inc.
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net;
using JsonFx.Json;
using BrainCloud.Internal;

namespace BrainCloud
{
    public class BrainCloudS3Handling
    {
        private BrainCloudClient m_brainCloudClientRef;

        public BrainCloudS3Handling(BrainCloudClient in_brainCloudClientRef)
        {
            m_brainCloudClientRef = in_brainCloudClientRef;
        }

        /// <summary>
        /// Sends an array of file details and returns 
        /// the details of any of those files that have changed
        /// </summary>
        /// <remarks>
        /// Service Name - S3Handling
        /// Service Operation - GetUpdatedFiles
        /// </remarks>
        /// <param name="in_category">  
        /// Category of files on server to compare against
        /// </param>
        /// <param name="in_fileDetailsJson">  
        /// An array of file details
        /// </param>
        /// <param name="in_success">
        /// The success callback.
        /// </param>
        /// <param name="in_failure">
        /// The failure callback.
        /// </param>
        /// <param name="in_cbObject">
        /// The user object sent to the callback.
        /// </param>
        public void GetUpdatedFiles(
            string in_category,
            string in_fileDetailsJson,
            SuccessCallback in_success = null,
            FailureCallback in_failure = null,
            object in_cbObject = null)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            if (Util.IsOptionalParameterValid(in_category))
            {
                data[OperationParam.S3HandlingServiceFileCategory.Value] = in_category;
            }

            data[OperationParam.S3HandlingServiceFileDetails.Value] = JsonReader.Deserialize<object[]>(in_fileDetailsJson);

            ServerCallback callback = BrainCloudClient.CreateServerCallback(in_success, in_failure, in_cbObject);
            ServerCall sc = new ServerCall(ServiceName.S3Handling, ServiceOperation.GetUpdatedFiles, data, callback);
            m_brainCloudClientRef.SendRequest(sc);
        }

        /// <summary>
        /// Retrieves the details of custom files stored on the server
        /// </summary>
        /// <remarks>
        /// Service Name - S3Handling
        /// Service Operation - GetFileList
        /// </remarks>
        /// <param name="in_category">  
        /// Category of files to retrieve
        /// </param>
        /// <param name="in_success">
        /// The success callback.
        /// </param>
        /// <param name="in_failure">
        /// The failure callback.
        /// </param>
        /// <param name="in_cbObject">
        /// The user object sent to the callback.
        /// </param>
        public void GetFileList(
            string in_category,
            SuccessCallback in_success = null,
            FailureCallback in_failure = null,
            object in_cbObject = null)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();

            if (Util.IsOptionalParameterValid(in_category))
            {
                data[OperationParam.S3HandlingServiceFileCategory.Value] = in_category;
            }

            ServerCallback callback = BrainCloudClient.CreateServerCallback(in_success, in_failure, in_cbObject);
            ServerCall sc = new ServerCall(ServiceName.S3Handling, ServiceOperation.GetFileList, data, callback);
            m_brainCloudClientRef.SendRequest(sc);
        }

        /// <summary>
        /// Returns the CDN URL for a file
        /// </summary>
        /// <param name="fileId">ID of file</param>
        /// <param name="success">The success callback</param>
        /// <param name="failure">The failure callback</param>
        /// <param name="cbObject">The callback object</param>
        public void GetCDNUrl(
            string fileId,
            SuccessCallback success = null,
            FailureCallback failure = null,
            object cbObject = null)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data[OperationParam.S3HandlingServiceFileId.Value] = fileId;

            ServerCallback callback = BrainCloudClient.CreateServerCallback(success, failure, cbObject);
            ServerCall sc = new ServerCall(ServiceName.S3Handling, ServiceOperation.GetCdnUrl, data, callback);
            m_brainCloudClientRef.SendRequest(sc);
        }
    }
}