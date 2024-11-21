using BusinessLayer.Abstaract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class OpenPositionManager : IOpenPositionService
    {
        private readonly IOpenPositionDal _openPositionDal;
        public OpenPositionManager(IOpenPositionDal openPositionDal)
        {
            _openPositionDal = openPositionDal;
        }

        public void Add(OpenPosition op)
        {
             _openPositionDal.Insert(op);
        }

        public void Delete(OpenPosition op)
        {
            _openPositionDal.Delete(op);
        }

        public OpenPosition GetById(int id)
        {
            return _openPositionDal.GetById(id);
        }

        public List<OpenPosition> GetListAll()
        {
            return _openPositionDal.GetListAll();
        }

        public void Update(OpenPosition op)
        {
            _openPositionDal.Update(op);
        }
    }
}
