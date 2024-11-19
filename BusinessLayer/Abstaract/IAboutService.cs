using System;
using System.ComponentModel;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstaract;

public interface IAboutService
{
    void AboutAdd(About about);

    void AboutDelete(About about);
    void AboutUpdate(About about);

    List<About> GetListAll();

    About GetById (int id);
}
