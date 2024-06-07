using Linq.Data.Models;
using LinqAssignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.ComponentModel;
using System;
namespace LinqAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinqController : ControllerBase
    {
        LinqQueiries queiries;

        public LinqController() {
             queiries = new LinqQueiries();
        }
        
       
       
       
       
        
        //Check do we have any states having same population in all districts of it, if yes print them
        //Check do we have any country with same number of districts in all states, if yes print them
       

        [HttpGet("/Getallcountries")]
        public ActionResult GetAllCpountries()
        {
            return Ok(queiries.GetAllCountries());
        }
        [HttpGet("/GetallStates")]
        public ActionResult GetAllStates() {
         return Ok(queiries.GetAllStatesofCountry());
        }
        [HttpGet("/GetAllDistricts")]
        public ActionResult GetAllDistricts() { 
        return Ok(queiries.GetDistricts());
        }

        [HttpGet("/GetStatesWithWholePopulation")]
        public ActionResult GetStatesWithWholePopulation()
        {
            return Ok(queiries.GetStatesWithTotalPopulation());
        }

        [HttpGet("/GetCountriesWithWholePopulation")]
        public ActionResult GetCountriesWithWholePopulation()
        {
            return Ok(queiries.GetCountriesWithTotalPopulation());
        }


        [HttpGet("/GetTop5MostPopulatedDistrictsAcrossCountries")]
        public ActionResult Top5PopulatedDistrictsInCountry()
        {
            return Ok(queiries.GetTop5MostPopulatedDistricts());
        }

        [HttpGet("/GetMostPopulatedDistrictsInState")]
        public ActionResult GetTopDistrictsPerState()
        {
            return Ok(queiries.GetTopDistrictsPerState());
        }

        [HttpGet("/GetTopPopulatedCountry")]
        public ActionResult GetTopPopulatedCountry()
        {
            return Ok(queiries.GetMostPopulatedCountry());
        }
        [HttpGet("/VowelCountry")]
        public ActionResult GetVowelInNameCountry()
        {
            return Ok(queiries.GetFirstCountryWithTwoVowels());
        }
        [HttpGet("/VowelCountryByName")]
        public ActionResult GetVowelInNameCountryOrdeByName()
        {
            return Ok(queiries.GetFirstCountryWithTwoVowelsOrderByName());
        }

        [HttpGet("/CountriesWithStateCount")]
        public ActionResult CountriesWithStateCount()
        {
            return Ok(queiries.StateCount());
        }


        [HttpGet("/CountriesWithDistrictCount")]
        public ActionResult CountriesWithDistrictCount()
        {
            return Ok(queiries.DistrictCount());
        }
        [HttpGet("/CountriesWithoutStates")]
        public ActionResult CountriesWithoutStates()
        {
            return Ok(queiries.Nostates());
        }

        [HttpGet("/PopulationMoreThan500")]
        public ActionResult PopulationMoreThan500()
        {
            return Ok(queiries.DistrictsWithPopulation500());
        }

        [HttpGet("/StatesMoreThan5Districts")]
        public ActionResult StatesMoreThan5Districts() { 
            return Ok(queiries.StatesWithDistrictsGreaterThan5());
        }

        [HttpGet("/CountriesLessthan2States")]
        public ActionResult CountriesLessthan2States()
        {
            return Ok(queiries.CountriesWithStatesGreaterThan5());
        }








    }
}
