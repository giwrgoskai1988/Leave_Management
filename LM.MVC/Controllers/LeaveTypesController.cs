﻿using LM.MVC.Contracts;
using LM.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace LM.MVC.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        // GET: LeaveTypesController
        public async Task<ActionResult> Index()
        {
            var model = await _leaveTypeService.GetLeaveTypes();
            return View(model);
        }

        // GET: LeaveTypesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(model);
        }

        // GET: LeaveTypesController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeVM createLeaveTypeVM)
        {
            try
            {
                var response = await _leaveTypeService.CreateLeaveType(createLeaveTypeVM);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, response.ValidationErros);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }

        // GET: LeaveTypesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _leaveTypeService.GetLeaveTypeDetails(id);
            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LeaveTypeVM leaveType)
        {
            try
            {
                var response = await _leaveTypeService.UpdateLeaveType(id, leaveType);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, response.ValidationErros);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(leaveType);
        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _leaveTypeService.DeleteLeaveType(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, response.ValidationErros);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return BadRequest();
        }
    }
}
