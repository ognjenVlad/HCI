package com.project.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.project.domain.Software;

public interface SoftwareRepository extends JpaRepository<Software, Long>{

}
