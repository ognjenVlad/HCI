package com.project.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.project.domain.Departman;
import com.project.service.DepartmanService;

@RequestMapping("departman")
@RestController
public class DepartmanController {

	@Autowired
	DepartmanService departmanService;
	
	@RequestMapping(value = "/add",method = RequestMethod.POST,
			consumes = MediaType.APPLICATION_JSON_VALUE,
			produces = MediaType.APPLICATION_JSON_VALUE)
	public Departman save(@RequestBody Departman u){
		return departmanService.save(u);
	}
	
	@RequestMapping(value = "/change",method = RequestMethod.POST,
			consumes = MediaType.APPLICATION_JSON_VALUE,
			produces = MediaType.APPLICATION_JSON_VALUE)
	public Departman change(@RequestBody Departman u){

		return departmanService.change(u);
		
	}
	
	@RequestMapping(value = "/delete",method = RequestMethod.POST,
			consumes = MediaType.APPLICATION_JSON_VALUE,
			produces = MediaType.APPLICATION_JSON_VALUE)
	public boolean delete(@RequestBody Departman u){

		return departmanService.delete(u);
		
	}
}
