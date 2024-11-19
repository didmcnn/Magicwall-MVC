using System;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class JobApplicationRepository : IJobApplicationDal
{
    Context _context = new ();
    public void Add(JobApplication jobApplication)
    {
        _context.Add(jobApplication);
        _context.SaveChanges();
    }

    public void Delete(JobApplication jobApplication)
    {
        _context.Remove(jobApplication);
        _context.SaveChanges();
    }

    public List<JobApplication> GetAll()
    {
        return _context.JobApplications.ToList();
    }

    public JobApplication GetById(int id)
    {
        return _context.JobApplications.Find(id)!;
    }

    public void Update(JobApplication jobApplication)
    {
        _context.Update(jobApplication);
        _context.SaveChanges();
    }
}

