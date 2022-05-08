using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVVMTutorial.Models;

namespace MVVMTutorial.Services
{
    public class MockTrainingCourseDataStore : IDataStore<TrainingCourse>
    {
        readonly List<TrainingCourse> trainingCourseList;
        public MockTrainingCourseDataStore()
        {
            trainingCourseList = new List<TrainingCourse>()
            {
                new TrainingCourse()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "UI Patterns - MVVM in depth",
                    Date = new DateTime(2022,05,11),
                    PresentedBy = "Arthur Moyo"
                }
            };
        }
        public Task<bool> AddAsync(TrainingCourse item)
        {
            trainingCourseList.Add(item);
            return Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var oldItem = trainingCourseList.Where((TrainingCourse arg) => arg.Id == id).FirstOrDefault();
            trainingCourseList.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<TrainingCourse> GetByIdAsync(string id)
        {
            return await Task.FromResult(trainingCourseList.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<TrainingCourse>> GetAllAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(trainingCourseList);
        }

        public async Task<bool> UpdateAsync(TrainingCourse item)
        {
            var oldItem = trainingCourseList.Where((TrainingCourse arg) => arg.Id == item.Id).FirstOrDefault();
            trainingCourseList.Remove(oldItem);
            trainingCourseList.Add(item);

            return await Task.FromResult(true);
        }
    }
}
