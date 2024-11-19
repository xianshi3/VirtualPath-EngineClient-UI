#pragma once

#include "GLObject.h"

namespace VirtualPathCore
{
	class Shader : public GLObject
	{
	public:
		Shader(GLenum shaderType, std::string source);
		~Shader();
	};
}