package com.project.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.project.domain.Course;
import com.project.service.CourseService;

@RequestMapping("course")
@RestController
public class CourseController {

	@Autowired
	CourseService courseService;
	
	@RequestMapping(value = "/add",method = RequestMethod.POST,
			consumes = MediaType.APPLICATION_JSON_VALUE,
			produces = MediaType.APPLICATION_JSON_VALUE)
	public Course save(@RequestBody Course u){
		return courseService.save(u);
	}
	
	@RequestMapping(value = "/change",method = RequestMethod.POST,
			consumes = MediaType.APPLICATION_JSON_VALUE,
			produces = MediaType.APPLICATION_JSON_VALUE)
	public Course change(@RequestBody Course u){

		return courseService.change(u);
		
	}
	
	@RequestMapping(value = "/delete",method = RequestMethod.POST,
			consumes = MediaType.APPLICATION_JSON_VALUE,
			produces = MediaType.APPLICATION_JSON_VALUE)
	public boolean delete(@RequestBody Course u){

		return courseService.delete(u);
		
	}
}
