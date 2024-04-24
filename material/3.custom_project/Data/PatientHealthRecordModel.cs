using Hl7.Fhir.Introspection;
using Ihis.FhirEngine.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Synapxe.FhirNexus.Custom.Data
{
    [FhirType("PatientHealthRecord", IsResource = true)]
    [PrimaryKey(nameof(Id), nameof(VersionId))]
    public class PatientHealthRecordModel : IResourceEntity<Guid>
    {
        public Guid Id { get; set; }

        public int? VersionId { get; set; }

        public bool IsHistory { get; set; }

        public bool? Status { get; set; }

        public LifestyleEntity? LifestyleRecord { get; set; }

        public List<FamilyHistoryEntity> FamilyHistoryRecords { get; set;}

        public DateTimeOffset? LastUpdated { get; set; }

        public byte[]? TimeStamp { get; set; }
    }

    [Owned]
    public class LifestyleEntity
    {
        public string? Smoking { get; set; }

        public string? AlcoholConsumption { get; set; }

        public string? ExerciseFrequency { get; set; }
    }
    
    [Owned]
    public class FamilyHistoryEntity
    {
        public string? Condition { get; set; }

        public string? Relationship { get; set; }
    }
}
