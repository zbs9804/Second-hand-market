// import { Container, CssBaseline, ThemeProvider, createTheme } from "@mui/material";
// import Header from "./Header";
// import { useState } from "react";
// import { Outlet } from "@mui/icons-material";

// function App() {

//   const [darkMode, setDarkMode] = useState(false);
//   const paletteType = darkMode ? 'dark' : 'light';
//   const theme = createTheme( {
//     palette: {
//       mode: paletteType,
//       // background: {
//       //   default: paletteType=== 'light' ? '#eaeaea' : '#121212'
//       // }
//     }
//   })

//   function handleThemeChange() {
//     setDarkMode(!darkMode);
//   }

//   return (
//     // we are no longer use a <div> block, instead we use a ThemeProvider as the top element
//     <ThemeProvider theme={theme}>

//       {/* so all .css named.app will change style of this class, we can also do this in-line, like 
//       <h1 style={{color:'red'}}>ReStore</h1>  note we used {{}} to indicate a .css object*/}
  
//       <CssBaseline />
      
//       <Header darkMode={darkMode} handleThemeChange={handleThemeChange}/>
      
//       <Container>
//           {/*we are at the root component, and we no longer need <Catalog /> here, use Outlet in router 
//          instead, now when the postfix of URL changes, the webpage will also routed to corresponding page*/}
//           <Outlet />
//       </Container>

//     </ThemeProvider>
//   );
// }

// export default App;
import { Container, createTheme, CssBaseline, ThemeProvider } from "@mui/material";
import { useState } from "react";
import { Outlet } from "react-router-dom";
import Header from "./Header";

function App() {
  const [darkMode, setDarkMode] = useState(false);
  const palleteType = darkMode ? 'dark' : 'light';
  const theme = createTheme({
    palette: {
      mode: palleteType,
      background: {
        default: (palleteType === 'light') ? '#eaeaea' : '#121212'
      }
    }
  })
  function handleThemeChange() {
    setDarkMode(!darkMode);
  }
  
  return (
    // we are no longer use a <div> block, instead we use a ThemeProvider as the top element
    <ThemeProvider theme={theme}>

      {/* so all .css named.app will change style of this class, we can also do this in-line, like 
      <h1 style={{color:'red'}}>ReStore</h1>  note we used {{}} to indicate a .css object*/}
  
      <CssBaseline />
      
      <Header darkMode={darkMode} handleThemeChange={handleThemeChange}/>
      
      <Container>
          {/*we are at the root component, and we no longer need <Catalog /> here, use Outlet in router 
         instead, now when the postfix of URL changes, the webpage will also routed to corresponding page*/}
          <Outlet />
      </Container>

    </ThemeProvider>
  );
}
export default App;