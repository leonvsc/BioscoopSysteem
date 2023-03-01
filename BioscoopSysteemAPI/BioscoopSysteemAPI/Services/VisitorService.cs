using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioscoopSysteemAPI.Models;
using BioscoopSysteemAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public class VisitorService
{
    private readonly VisitorRepository visitorRepository;

    public VisitorService(VisitorRepository visitorRepository)
	{
        this.visitorRepository = visitorRepository;
	}

    public IsNumerable<Visitor> getVisitors()
    {
        var visitors = visitorRepository.GetVisitors();
        if (visitors == null)
        {
            return null;    
        }
        return visitors;
    }
}
