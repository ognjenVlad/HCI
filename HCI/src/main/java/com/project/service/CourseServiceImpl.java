package com.project.service;

import org.springframework.beans.factory.annotation.Autowired;

import com.project.domain.Course;
import com.project.repository.CourseRepository;

public class CourseServiceImpl implements CourseService {

	@Autowired
	CourseRepository courseRepository;
	@Override
	public Course save(Course u) {
		Course course = courseRepository.findByLabel(u);
		if(course != null){
			return null;
		}
		return courseRepository.save(u);
	}

	@Override
	public boolean delete(Course u) {
		courseRepository.delete(u);
		return true;
	}

	@Override
	public Course change(Course u) {
		
		Course course = courseRepository.findByLabel(u);
		course.setLabel(u.getLabel());
		course.setDescription(u.getDescription());
		course.setGroupSize(u.getGroupSize());
		course.setClassNumber(u.getClassNumber());
		course.setName(u.getName());
		course.setOs(u.getOs());
		course.setProjector(u.isProjector());
		course.setSmartTable(u.isSmartTable());
		course.setTableExists(u.isTableExists());
		course.setDepartman(u.getDepartman());
		course.setAppointmentsNumber(u.getAppointmentsNumber());
		
		return courseRepository.save(course);
	}

}
