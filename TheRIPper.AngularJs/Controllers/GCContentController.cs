﻿using Bio;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TheRIPper.BL.GCContent;
using TheRIPper.BL.SequenceHelpers;

namespace TheRIPper.AngularJs.Controllers
{
    public class GCContentController : Controller
    {
        [HttpGet]
        [Route("api/gccontent/sequence/{SequenceId}")]
        public JsonResult GCContentSingleSequenceTotal(int SequenceId) {
            double GCContent = GCContentLogic.GCContentSingleSequenceTotal(SequenceHelpers.GetSequenceBySequenceId(SequenceId));
            return new JsonResult(JsonConvert.SerializeObject(GCContent)) { ContentType = "application/json", StatusCode = 200 };
        }

        [HttpGet]
        [Route("api/gccontent/file/{FileId}")]
        public JsonResult GCContentFileTotal(int FileId) {
            List<ISequence> sequences = SequenceHelpers.GetISequencesFromDatabaseByFileId(FileId);
            ISequence mergedSequence = SequenceHelpers.MergeSequences(sequences);

            double GCContent = GCContentLogic.GCContentSingleSequenceTotal(mergedSequence);

            return new JsonResult(JsonConvert.SerializeObject(GCContent)) { ContentType = "application/json", StatusCode = 200 };
        }
    }
}