namespace API.Repositories
{
    using API.Interfaces.Data;
    using API.Interfaces.Repositories;
    using API.Models;

    public class HeadsetDataRepository : IHeadsetDataRepository
    {
        private readonly IApplicationData applicationData;

        public HeadsetDataRepository(IApplicationData applicationData)
        {
            this.applicationData = applicationData;
        }
        public Task<List<HeadsetDataModel>> GetAllAsync()
        {
            return Task.FromResult(applicationData.HeadsetData.ToList());
        }
    }
}
