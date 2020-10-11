using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ShopMonitoring.Data;
using ShopMonitoring.Dtos;
using ShopMonitoring.Models;

namespace ShopMonitoring.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepo _customerRepo;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepo customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        // GET api/customers
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllCustomers(DateTime? startDate, DateTime? endDate)
        {
            var customers = _customerRepo.GetAllCustomers(startDate, endDate);
            return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(customers));
        }

        // GET api/customers/5
        [HttpGet("{id}", Name="GetCustomerById")] 
        public ActionResult<CustomerReadDto> GetCustomerById(int id)
        {
            var customer = _customerRepo.GetCustomerById(id);
            if (customer != null)
                return Ok(_mapper.Map<CustomerReadDto>(customer));
            return NotFound();
        }

        // POST api/customers
        [HttpPost]
        public ActionResult<IEnumerable<CustomerReadDto>> CreateCustomers(IEnumerable<CustomerCreateDto> customerCreateDtos)
        {
            // TODO: add validations as - at least 1 entity arrived, sex is either 'M' or 'F', etc..

            var customers = _mapper.Map<IEnumerable<Customer>>(customerCreateDtos);
            _customerRepo.CreateCustomers(customers);
            _customerRepo.SaveChanges();

            var customersIds = customers.Select(x => x.Id).ToArray();

            var customersFromRepo = _customerRepo.GetCustomersByIds(customersIds);
            if (customersFromRepo.All(x => x != null))
                return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(customersFromRepo));
            return NotFound();
        }

        // NOTE: Post call for single entity - we can use CreateCustomers with single entity instead
        // POST api/customers
        //[HttpPost]
        //public ActionResult<CustomerReadDto> CreateCustomer(CustomerCreateDto customerCreateDto)
        //{
        //    var customer = _mapper.Map<Customer>(customerCreateDto);
        //    _customerRepo.CreateCustomer(customer);
        //    _customerRepo.SaveChanges();

        //    var customerReadDto = _mapper.Map<CustomerReadDto>(customer);

        //    return CreatedAtRoute(nameof(GetCustomerById), new {Id = customerReadDto.Id}, customerReadDto);
        //}
    }
}
