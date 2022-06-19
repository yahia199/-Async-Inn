using Amenities_App.Services.Repositire;
using Hotel_App.Data;
using Hotel_App.Model;
using Hotel_App.Services.Interface;
using Hotel_App.Services.Repositire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Room_App.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_App
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                // There are other options like this
            }).AddEntityFrameworkStores<AsyncInnDbContext>();

            services.AddTransient<IUserService, IdentityUserService>();
            services.AddControllers();
            services.AddTransient<IHotels, HotelsRepo>();
            services.AddTransient<IRooms, RoomsRepo>();
            services.AddTransient<IAmenities, AmenitiesRepo>();
            services.AddScoped<JwtTokenService>();
            services.AddControllers()
                    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<AsyncInnDbContext>(options =>
            {
                // Our DATABASE_URL from js days
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            // Add the wiring for adding "Authentication" for our API
            // "We want the system to always use these "Schemes" to authenticate us
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(options =>
              {
       // Tell the authenticaion scheme "how/where" to validate the token + secret
       options.TokenValidationParameters = JwtTokenService.GetValidationParameters(Configuration);
              }); services.AddAuthorization(options =>
              {
                  // Add "Name of Policy", and the Lambda returns a definition
                  options.AddPolicy("Create Hotel", policy => policy.RequireClaim("permissions", "Create Hotel"));
                  options.AddPolicy("See Hotels", policy => policy.RequireClaim("permissions", "See Hotels"));
                  options.AddPolicy("Update Hotel", policy => policy.RequireClaim("permissions", "Update Hotel"));
                  options.AddPolicy("Delete Hotel", policy => policy.RequireClaim("permissions", "Delete Hotel"));
                  options.AddPolicy("Create HotelRoom", policy => policy.RequireClaim("permissions", "Create HotelRooms"));
                  options.AddPolicy("See HotelRooms", policy => policy.RequireClaim("permissions", "See HotelRooms"));
                  options.AddPolicy("Update HotelRooms", policy => policy.RequireClaim("permissions", "Update HotelRooms"));
                  options.AddPolicy("Delete HotelRooms", policy => policy.RequireClaim("permissions", "Delete HotelRooms"));
                  options.AddPolicy("Create Rooms", policy => policy.RequireClaim("permissions", "Create Rooms"));
                  options.AddPolicy("See Rooms", policy => policy.RequireClaim("permissions", "See Rooms"));
                  options.AddPolicy("Update Rooms", policy => policy.RequireClaim("permissions", "Update Rooms"));
                  options.AddPolicy("Delete Rooms", policy => policy.RequireClaim("permissions", "Delete Rooms"));
                  options.AddPolicy("Create Amenity", policy => policy.RequireClaim("permissions", "Create Amenity"));
                  options.AddPolicy("See Amenities", policy => policy.RequireClaim("permissions", "See Amenities"));
                  options.AddPolicy("Add Amenity to Room", policy => policy.RequireClaim("permissions", "Add Amenity to Room"));
                  options.AddPolicy("Delete Amenity From Room", policy => policy.RequireClaim("permissions", "Delete Amenity From Room"));
                  options.AddPolicy("Update Amenity", policy => policy.RequireClaim("permissions", "Update Amenity"));
                  options.AddPolicy("Delete Amenity", policy => policy.RequireClaim("permissions", "Delete Amenity"));
              });

            services.AddMvc();
            services.AddSwaggerGen(options =>
            {
                // Make sure get the "using Statement"
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Hotel Demo",
                    Version = "v1",
                }); options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                              Type = ReferenceType.SecurityScheme,
                              Id = "Bearer"
                            }
                        },
                        new string[] {}
                }
               });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
            if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                app.UseRouting();
            app.UseSwagger(options => {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Hotel Demo");
               options.RoutePrefix = "";
            });

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                    endpoints.MapGet("/", async context =>
                    {
                        await context.Response.WriteAsync("Hello World!");
                    });
                });
            }
        }
    }

