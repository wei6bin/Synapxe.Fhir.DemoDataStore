// -------------------------------------------------------------------------------------------------
// Copyright (c) Integrated Health Information Systems Pte Ltd. All rights reserved.
// -------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace Synapxe.FhirNexus.Custom.Data;

public class FhirModelDbContext : DbContext
{
    public FhirModelDbContext(DbContextOptions<FhirModelDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<PatientHealthRecordModel> PatientHealthRecord => Set<PatientHealthRecordModel>();
}
