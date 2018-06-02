package com.project.service;

import com.project.domain.Software;

public interface SoftwareService {
	Software save(Software u);
	boolean delete(Software u);
	Software change(Software u);
}
